using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class TrueAds : MonoBehaviour
{
    public string AppID;
    public string BannerAdUnitID;

    private BannerView bannerView;
    // Start is called before the first frame update
   public void LetsGO()
    {
        MobileAds.Initialize(AppID);
        Debug.Log("1234");
        bannerView = new BannerView(BannerAdUnitID, AdSize.Banner, AdPosition.Top);
        bannerView.LoadAd(new AdRequest.Builder().Build());
    }

    
}
