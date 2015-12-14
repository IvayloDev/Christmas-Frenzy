using UnityEngine;
using System.Collections;
using GoogleMobileAds;

public class Ads : MonoBehaviour {

	private AdMobPlugin admob;
	private const string Interstitial_ID = "ca-app-pub-4847787002677683/3801410656";
	private const string Banner_ID = "ca-app-pub-4847787002677683/3323732650";
	public static int adCount = 0;

	void Awake () {
		admob = GetComponent<AdMobPlugin>();
		admob.CreateBanner(Banner_ID,AdMobPlugin.AdSize.SMART_BANNER,true, Interstitial_ID);
		admob.RequestAd();
		if(Lives.AdCount == 2){
		admob.RequestInterstitial();
			Lives.AdCount = 0;
		}
	}
	void Update () {
		HandleInterstitialLoaded();

	}
	void OnEnable(){
		AdMobPlugin.InterstitialLoaded += HandleInterstitialLoaded;
	}
	
	void OnDisable() {
		
		AdMobPlugin.InterstitialLoaded -= HandleInterstitialLoaded;
		
	}
	
	public void HandleInterstitialLoaded() {

		if(Lives.ShowAd){
				admob.ShowInterstitial();
			}
		}
	}


