using UnityEngine;
using System.Collections;

public class Runner2D : MonoBehaviour {
	private IngameMenu menu;
	public float velocity;
	public float tmpVelocity;
	public float jumpHeight;
	private level levelHandle;
	private bool touchingPlatform;
	private float tmpX;

	private Vector3 vel;
	private Animator animator;
	public bool triggered;
	public bool trueTriggered;
	public bool falseTriggered;
	private bool jump;
	private float triggeredTime;
	private float curHeight;
	private float prevHeight;
	private bool fall;
	private float score;
	private float tmpScore;
	public GUIText textScore;
	//behaviour
	void Die() {
		//Debug.Log("Trigger Die");
		menu.GameOver ();
		//Time.timeScale = 0;
		//MasterData.currentLevel = 0;
		//Application.LoadLevel ("World Map");
	}

	void Jump() {
		//Debug.Log("jumped");
		jump = true;
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight));
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight), ForceMode2D.Force);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpHeight * Time.deltaTime * 4.0f), ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
	}

	void Win() {
		//Debug.Log ("Wiin");
		menu.Congrats ();
	}

	// Use this for initialization
	void Start () {
		GameObject menuObj = GameObject.Find ("Menu");
		menu = menuObj.GetComponent <IngameMenu>();
		Time.timeScale = 1;
		animator = this.GetComponent<Animator> ();
		animator.SetInteger("State", 0);
		triggered = false;
		triggeredTime = 0;
		jump = false;
		trueTriggered = false;
		falseTriggered = false;
		curHeight = prevHeight = 0.0f;
		score = tmpScore = 0;
		textScore.text = "0000";
		tmpVelocity = velocity;
		GameObject levelObject = GameObject.Find ("Level Handle");
		levelHandle = levelObject.GetComponent <level>();
	}
	
	// Update is called once per frame
	void Update () {		
		curHeight = transform.position.y;
		float travel = curHeight - prevHeight;
		if (travel < 0) {
			//Debug.Log("fall +");
			fall = true;
		} else if (travel > 0) {
			//Debug.Log("fall -");
			fall = false;
		}
		//resume
		//Debug.Log (Time.deltaTime);
		/*if(Input.GetButtonDown("Submit")){
			Time.timeScale = 1.0f;
		}*/
		if (touchingPlatform && (Input.GetKeyDown("space")/*GetButtonDown ("Jump") || Input.touchCount > 0*/)) {
			Jump();
		}
		//state 
		//0 - run
		//1 - jump
		//2 - wrong
		//3 - fall
		//4 - true
		if (touchingPlatform && !triggered && !fall) {
			animator.SetInteger("State", 0);
		}
		if (!touchingPlatform && !triggered) {
			if (jump) {
				animator.SetInteger ("State", 1);
			}
			if (fall) {
				//Debug.Log("fall");
				animator.SetInteger ("State", 3);
			}
			if (trueTriggered) {
				triggeredTime += Time.deltaTime;
				if (triggeredTime > 0.4) {
					trueTriggered = false;
					triggeredTime = 0;
				}
				animator.SetInteger("State",4);
			}
			if(falseTriggered){
				triggeredTime += Time.deltaTime;
				if (triggeredTime > 0.4) {
					falseTriggered = false;
					triggeredTime = 0;
				}
				animator.SetInteger("State",2);
			}
		}
		if (triggered) {
			triggeredTime += Time.deltaTime;
			if (triggeredTime > 0.4) {
				triggered = false;
				triggeredTime = 0;
			}
			animator.SetInteger ("State", 2);
		}

		//move runner
		transform.Translate(velocity * Time.deltaTime, 0f, 0f);
		//Debug.Log (Application.loadedLevel + 1);
		//GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0f);
		prevHeight = curHeight;
		if (score != tmpScore) {
			if(score<1000 && score>0) textScore.text = "0" +score;
			else textScore.text = "" +score;
		}
	}

	void FixedUpdate(){
		if (touchingPlatform && Input.touchCount > 0) {
			Jump ();
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		triggered = true;
		if (col.gameObject.tag == "spike" || col.gameObject.tag == "box die") {
			Die ();
		}
		if (col.gameObject.tag == "item") {
			Destroy(col.gameObject);
			triggered=false;
		}
		if(col.gameObject.name == "batas"){
			tmpVelocity = 0;
			triggered=false;
		}
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "portal") {
			GetFinalScore();
			Debug.Log("Next Level");
			Win();
		}
		jump = false;
		fall = false;
		touchingPlatform = true;
	}

	void GetFinalScore(){
		float FinalScore;
		FinalScore = score / levelHandle.scoreMax;
		if(FinalScore < 0.34)
			Debug.Log("Bintang 1");
		else if (FinalScore < 0.76) 
			Debug.Log("Bintang 2");
		else if (FinalScore <= 1) 
			Debug.Log("Bintang 3");
	}

	public void AddScore (float scoreValue){
		score += scoreValue;
	}
	
	void OnCollisionExit2D () {
		touchingPlatform = false;
	}
}
