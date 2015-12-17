using UnityEngine;
using System.Collections;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayGamesGPG : MonoBehaviour {

	public int UserCancelledInt;

	void Awake () {
		UserCancelledInt = PlayerPrefs.GetInt("UserCancelledInt", 0);	
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		
		GooglePlayGames.PlayGamesPlatform.Activate();
	}
	
	void Start () {
		if(UserCancelledInt == 0){
		Social.localUser.Authenticate(
			(bool success) => {
				if(!success){
					UserCancelledInt = 1;
					}
			});
		}
	}

	void OnDestroy(){
		PlayerPrefs.SetInt("UserCancelledInt",UserCancelledInt);
	}

}
