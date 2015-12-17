using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	Text LivesText;
	public static int LivesCount;
	public Animator RestartAnim;
	public Animator AchievementAnim;
	public Animator LeaderBoardAnim;
	public Animator ShareAnim;
	public static bool isDead= false;
	public static bool NotPressed = true;
	public GameObject PauseButton;
	public GameObject ScoreText;
	public GameObject StartCounter;
	public GameObject Bag;
	public GameObject HighScoreText;
	public static int AdCount;
	public static bool ShowAd;
	public GameObject LeaderBoardButt,AchievementsButt,ShareButt;

	// Use this for initialization
	void Start () {
		AchievementsButt.SetActive(false);
		LeaderBoardButt.SetActive(false);
		ShareButt.SetActive(false);
		ShowAd = false;
		isDead = false;
		NotPressed = true;
		LivesCount = 1;
		LivesText = GetComponent<Text>();
		//HighScoreText.SetActive(false);
	}

	void OnLost() {
			AchievementsButt.SetActive(true);
			LeaderBoardButt.SetActive(true);
			ShareButt.SetActive(true);
			isDead = true;
			RestartAnim.SetBool("Restart",true);
			Bag.SetActive(false);
			PauseButton.SetActive(false);
			HighScoreText.SetActive(true);
			StartCounter.SetActive(false);
			AdCount++;
			ShowAd = true;
			AchievementAnim.SetBool("EndGameButtons",true);
			LeaderBoardAnim.SetBool("EndGameButtons",true);
			ShareAnim.SetBool("EndGameButtons",true);
			ButtonScript.ShowHighScore = true;

		if(Social.localUser.authenticated){

			Social.ReportScore(HighScoreScript.HighScore,"CgkI8sLw9sgQEAIQAQ", (bool success) => {
			});

			
			if(HighScoreScript.HighScore >= 20) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQAg", 100.0f, (bool success) => {
				});
			}

			
			if(HighScoreScript.HighScore >= 50) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQAw", 100.0f, (bool success) => {
				});
			}

			
			if(HighScoreScript.HighScore >= 100) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQBA", 100.0f, (bool success) => {
				});
			}

			
			if(HighScoreScript.HighScore >= 200) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQBQ", 100.0f, (bool success) => {
				});
			}

			
			if(HighScoreScript.HighScore >= 300) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQBg", 100.0f, (bool success) => {
				});
			}

			
			if(HighScoreScript.HighScore >= 400) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQBw", 100.0f, (bool success) => {
				});
			}

			if(HighScoreScript.HighScore >= 500) {
				Social.ReportProgress("CgkI8sLw9sgQEAIQCA", 100.0f, (bool success) => {
				});
			}


		}

	
	}


	// Update is called once per frame
	void Update () {
		if(ButtonScript.ShowHighScore){
			HighScoreText.SetActive(true);
		}else{
			HighScoreText.SetActive(false);
		}

		if(isDead  || NotPressed){
			LivesText.text = "";

		}else{
		LivesText.text = "" + LivesCount;
		}

		if (LivesCount < 0) {
			LivesCount = 0;
			OnLost();
		}

		if(NotPressed){
			Bag.SetActive(false);
			PauseButton.SetActive(false);
			ScoreText.SetActive(false);
			StartCounter.SetActive(false);
		}
		else if(!NotPressed && !isDead){
			Bag.SetActive(true);
			PauseButton.SetActive(true);
			ScoreText.SetActive(true);
			StartCounter.SetActive(true);
		}

	}
}
