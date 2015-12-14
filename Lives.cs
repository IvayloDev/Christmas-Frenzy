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
		LivesCount = 2;
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
