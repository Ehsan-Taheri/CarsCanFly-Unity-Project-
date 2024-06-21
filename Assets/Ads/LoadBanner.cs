using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using System;

public class LoadBanner : MonoBehaviour
{
    public string AppleID;
    public string AndroidID;
    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    string adsID;
    private void Start()
    {
        #if UNITY_IOS
        adsID= AppleID;
        #elif UNITY_ANDROID
        adsID = AndroidID;

        #endif
        Advertisement.Banner.SetPosition(bannerPosition);


    }
    public void Load()
    {
        BannerLoadOptions bannerLoadOptions = new BannerLoadOptions
        {
            loadCallback = OnLoaded,
            errorCallback = OnloadError
            
        };
        Advertisement.Banner.Load(adsID, bannerLoadOptions);
    }
    void OnLoaded()
    {
        print("Banner is loaded");
        ShowAdBanner();

    }

    void OnloadError(string error)
    {
        print("ERROR: "+error);
    }


    private void ShowAdBanner()
    {
        BannerOptions bannerOptions = new BannerOptions
        {
            clickCallback = OnClick,
            showCallback = OnShow,
            hideCallback = OnHide
        };
    }

    private void OnHide()
    {
        
    }

    private void OnShow()
    {
        print("banner shown");
    }

    private void OnClick()
    {
        
    }
    public void HiddenBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}

