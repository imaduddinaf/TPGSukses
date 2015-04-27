using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public GUIText tutorialText;
	private int tutorialCount;
	// Use this for initialization
	void Start () {
		tutorialCount = 1;
		InvokeRepeating("TutorialText", 1f, 2.8f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TutorialText(){
		if (tutorialCount == 1) {
			tutorialText.text = "Selamat Datang di Operuntion";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 2) {
			tutorialText.text = "Bawa sang character menuju portal\n untuk menyelesaikan satu level";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 3) {
			tutorialText.text = "Hindari spike dengan meloncat.\nTap untuk meloncat";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 4) {
			tutorialText.text = "Hindari box dengan meloncat.\nTap untuk meloncat";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 5) {
			tutorialText.text = "Box dapat dinaiki diatasnya.\nTap untuk meloncat";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 6) {
			tutorialText.text = "Character harus menuju portal\n sebelum energy-nya habis";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		} else if (tutorialCount == 7) {
			tutorialText.text = "Untuk mengisi energy,\n Ambil battery dengan hasil operasi yang sesuai dengan kode Character";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		}  else if (tutorialCount == 8) {
			tutorialText.text = "Hindari battery dengan hasil operasi yang tidak sesuai dengan kode Character\nSalah battery menyebabkan energy berkurang";
			Invoke ("EmptyText", 2f);
			tutorialCount++;
		}

	}

	void EmptyText(){
		tutorialText.text = "";
	}
}
