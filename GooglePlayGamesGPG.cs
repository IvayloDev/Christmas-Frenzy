using UnityEngine;
using System.Collections;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayGamesGPG : MonoBehaviour {

	void Awake () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		
		GooglePlayGames.PlayGamesPlatform.Activate();
	}
	
	void Start () {
		Social.localUser.Authenticate(
			(bool success) => {
		});
		
	}
}
