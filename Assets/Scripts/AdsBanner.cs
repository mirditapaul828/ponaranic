using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdsBanner : MonoBehaviour
{
    private BannerView bannerView;
    
    public void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-9555402080206733~9026608209";
        #elif UNITY_IPHONE
        string appId = "ca-app-pub-9555402080206733~8721687572";
        #else
            string appId = "";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string bannerUnitId = "ca-app-pub-9555402080206733/6762518891";
        #elif UNITY_IPHONE
        string bannerUnitId = "ca-app-pub-9555402080206733/1447501081";
        #else
            string bannerUnitId = "";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(bannerUnitId, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }
}
