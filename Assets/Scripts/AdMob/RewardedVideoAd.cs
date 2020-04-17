using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class RewardedVideoAd : MonoBehaviour
{
    [SerializeField] private string APP_ID = "ca-app-pub-4584046040765403~6834778883";

    private RewardedAd rewardedAd;
    public int gamesPerAd;

    private void Awake()
    {
        MobileAds.Initialize(APP_ID);
        RequestRewardedVideoAd();
        
        if(PlayerPrefs.GetInt("GamesCounter", 0) < gamesPerAd)
        {
            PlayerPrefs.SetInt("GamesCounter", PlayerPrefs.GetInt("GamesCounter") + 1);
            //Debug.Log("if " + (PlayerPrefs.GetInt("GamesCounter", 0)));
        }
        else
        {
            Display_RewardedAD();
            PlayerPrefs.SetInt("GamesCounter", 0);
            //Debug.Log("else " + (PlayerPrefs.GetInt("GamesCounter", 0)));
        }
        
    }

    private void RequestRewardedVideoAd()
    {
        //FOR REAL APP
        string video_ID = "ca-app-pub-4584046040765403/2454241242";

        //FOR TESTING
        //string video_ID = "ca-app-pub-3940256099942544/5224354917";

        this.rewardedAd = new RewardedAd(video_ID);

        //FOR REAL APP
        AdRequest request = new AdRequest.Builder().Build();

        //FOR TESTING
        //AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        this.rewardedAd.LoadAd(request);
    }

    void HandleRewardedVideoADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening -= HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
        }
    }

    public void Display_RewardedAD()
    {

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }

    }


    //HANDLE EVENTS
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded show it
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        //ad failed to load load it again
        this.RequestRewardedVideoAd();

        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.RequestRewardedVideoAd();

        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {

        //EventsMananger.SharedInstance.Reward();


        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    ////////////////////////////////////////////////////////
    private void OnEnable()
    {
        //Debug.Log("video enabled");
        HandleRewardedVideoADEvents(true);
    }

    private void OnDisable()
    {
        HandleRewardedVideoADEvents(false);
    }
}
