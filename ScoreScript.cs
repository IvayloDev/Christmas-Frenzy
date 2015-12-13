using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	Text ScoreText;

	public static int Score;

	// Use this for initialization
	void Start () {
		Score = 0;
		ScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "" + Score;

		if(Score >= HighScoreScript.HighScore){
			HighScoreScript.HighScore = Score;
		}

		if(Score < 0){
			Score = 0;
		}
	}
}
