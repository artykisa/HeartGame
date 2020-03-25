using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
public class AddGoogle : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-4436802488375918~9631617011";

    private BannerView bannerAD;
    private InterstitialAd interstitialAD;
    private RewardBasedVideoAd rewardVideoAd;

    void Start()
    {
        //this is when i publish my app
        // MobileAds.Initialize(APP_ID); 

        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();
    }

    // Update is called once per frame
    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);
        //for real
        // AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);
    }
    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

        interstitialAD = new InterstitialAd(interstitial_ID);
        //for real
        // AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAD.LoadAd(adRequest);
    }
    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-3940256099942544/5224354917";

        rewardVideoAd = RewardBasedVideoAd.Instance;
        //for real
        // AdRequest adRequest = new AdRequest.Builder().Build();

        //for testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    }


    public void Display_Banner()
    {
        bannerAD.Show();
    }
    public void Display_IntertitialAD()
    {
        if (interstitialAD.IsLoaded())
        {
            interstitialAD.Show();
        }

    }

    public void Display_Reward_Video()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }


    //HANDLE EVENTS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //ad is loaded show it
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //try to load again
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

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

     void OnEnable()
    {
        HandleBannerADEvents(true);
    }
     void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}
