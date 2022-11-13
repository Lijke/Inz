using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdLoader : MonoBehaviour{
	private BannerView bannerView;
	private InterstitialAd interstitial;
	private RewardedAd rewardedAd;

	[SerializeField] private AdsRewardHandler adsRewardHandler;
// Start is called before the first frame update
	void Start(){
		MobileAds.Initialize(initStatus => { });
		RequestBanner();
	}
	
	private void RequestBanner(){
#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3384578948782200/2488788775";
#elif UNITY_IPHONE
string adUnitId = “ca-app-pub-3384578948782200/5139476574”;
#else
string adUnitId = “unexpected_platform”;
#endif

// Create a 320×50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();

// Load the banner with the request.
		this.bannerView.LoadAd(request);
	}

	public void RequestInterstitial(){
#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3384578948782200/4251111369";
#elif UNITY_IPHONE
string adUnitId = “ca-app-pub-3384578948782200/7902129453”;
#else
string adUnitId = “unexpected_platform”;
#endif

// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
// Load the interstitial with the request.
		interstitial.LoadAd(request);
		interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
	}

	private void Interstitial_OnAdLoaded(object sender, System.EventArgs e){
		interstitial.Show();
	}

	public void CreateAndLoadRewardedAd(){
#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3384578948782200/4251111369";
#elif UNITY_IPHONE
string adUnitId = “ca-app-pub-3940256099942544/1712485313”;
#else
string adUnitId = “unexpected_platform”;
#endif

		rewardedAd = new RewardedAd(adUnitId);

		rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
		rewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward;
		rewardedAd.OnAdClosed += RewardedAd_OnAdClosed;

// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
// Load the rewarded ad with the request.
		rewardedAd.LoadAd(request);
	}

	private void RewardedAd_OnAdClosed(object sender, System.EventArgs e){
		Debug.Log("[Ads] Reward closes");
//ad has been closed by the user
	}

	private void RewardedAd_OnUserEarnedReward(object sender, Reward e){
		Debug.Log("[Ads] Reward earned");
		adsRewardHandler.GiveReward();
		GameEvents.AdsEarnedReward();
//reward your user
	}

	private void RewardedAd_OnAdLoaded(object sender, System.EventArgs e){
		Debug.Log("[Ads] Reward Load");
		rewardedAd.Show();
	}
}