using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

	Text HighScoreText;
	public static int HighScore;

	// Use this for initialization
	void Start () {

		HighScore = 0;

		HighScore = PlayerPrefs.GetInt("HighScore", 0);

		HighScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
		HighScoreText.text = "HighScore :  " + HighScore;

	}

	void OnDestroy(){

		PlayerPrefs.SetInt("HighScore", HighScore); 

	}

}
