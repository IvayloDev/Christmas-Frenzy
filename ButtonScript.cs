using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ButtonScript : MonoBehaviour {

	public static bool Click2StartBool, ShowHighScore,Paused;
	public Sprite MusicOn,MusicOff;
	public static int MusicInt;
	public Animator ShopAnimator;
	public GameObject musicButt, ResumeButt, TutorialScreen,XButt;
	public AudioClip[] audioClip;
	public GoogleAnalyticsV3 googleAnalytics;
	


	public void PlaySound(int clip){
		
		GetComponent<AudioSource>().clip = audioClip[clip];
		GetComponent<AudioSource>().Play();
	}

	void Start() {
		ResumeButt.SetActive(false);
		PlaySound(0);
		MusicInt = 0;
		MusicInt = PlayerPrefs.GetInt("MusicInt", 0);
		ShowHighScore = false;
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Click2Start() {
		Click2StartBool = true;
	}

	public void OnPauseClick(){

		Paused = true;
		ResumeButt.SetActive(true);
		Time.timeScale = 0;

	}

	public void onResumeClick(){

		Paused = false;
		ResumeButt.SetActive(false);
		Time.timeScale = 1;

	}

	public void onInfoClick(){
		TutorialScreen.SetActive(true);
		XButt.SetActive(true);
		ShopAnimator.SetBool("ShopBack",true);
		ShopAnimator.SetBool("ShopTrue",false);
	}

	public void onXClick(){
		XButt.SetActive(false);
		TutorialScreen.SetActive(false);
	}

	public void onLeaderBoardClick(){
		if(Social.localUser.authenticated ){
		Social.ShowLeaderboardUI();
		}else{
			Social.localUser.Authenticate(
				(bool success) => {
			});
		}
	}
	
	public void onAchievementClick(){
		if(Social.localUser.authenticated){
			Social.ShowAchievementsUI();
		}else{
			Social.localUser.Authenticate(
				(bool success) => {
			});
		}
	}

	public void onShopClick(){
		ShopAnimator.SetBool("ShopTrue",true);
		ShopAnimator.SetBool("ShopBack",false);
		ShowHighScore = true;
	}

	public void OnShareClick() {

		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Check This Out !");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "I Just Scored " + ScoreScript.Score + " Points in Christmas Frenzy." +  " Download Now !  https://play.google.com/store/apps/details?id=com.IvayloDev.ChristmasFrenzy ");
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);

	}

	public void onMusicClick(){

		if(MusicInt == 0){
			MusicInt = 1;
			GetComponent<AudioSource>().Pause();
		}else{
			MusicInt = 0;
			GetComponent<AudioSource>().UnPause();
		}

	}
	void OnDestroy(){
		PlayerPrefs.SetInt("MusicInt", MusicInt);
	}

	void Update() {

		if(Input.GetKey(KeyCode.Escape)){
			TutorialScreen.SetActive(false);
		}
		
		if(MusicInt == 1){
			musicButt.GetComponent<Image>().sprite = MusicOff;
			AudioListener.volume = 0;
		}else if(MusicInt == 0){
			musicButt.GetComponent<Image>().sprite = MusicOn;
			AudioListener.volume = 1;
		}

	}



}
