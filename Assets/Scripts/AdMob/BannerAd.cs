using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour
{
    [SerializeField] private string APP_ID = "ca-app-pub-4584046040765403~6834778883";

    private BannerView bannerView;

    private void Awake()
    {
        MobileAds.Initialize(APP_ID);
        RequestBanner();
    }

    private void RequestBanner()
    {
        //FOR REAL APP
        string banner_ID = "ca-app-pub-4584046040765403/9269370536";

        //FOR TESTING
        //string banner_ID = "ca-app-pub-3940256099942544/6300978111";

        bannerView = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);

        //FOR REAL APP
        AdRequest request = new AdRequest.Builder().Build();

        //FOR TESTING
        //AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerView.LoadAd(request);
    }


    void HandleBannerADEvents(bool subscribe)
    {

        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            //this.bannerView.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerView.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerView.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerView.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerView.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }

    }

    public void Display_Banner()
    {
        bannerView.Show();
    }

    //HANDLE EVENTS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded show it
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //ad failed to load load it again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    private void OnEnable()
    {
        //Debug.Log("banner enabled");
        HandleBannerADEvents(true);
    }

    private void OnDisable()
    {
        HandleBannerADEvents(false);
    }

}
