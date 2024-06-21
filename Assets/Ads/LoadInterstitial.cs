using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class LoadInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string AppleID;
    public string AndroidID;


    string adsID;
    private void Awake()
    {
#if UNITY_IOS
        adsID= AppleID;
#elif UNITY_ANDROID
        adsID = AndroidID;

#endif

        
    }
    public void LoadAD()
    {
        print("loading interstitial");
        Advertisement.Load(adsID,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print(" interstitial loaded");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print(" interstitial failed");
    }

    public void ShowAd()
    {
        print("interstitial show");
        Advertisement.Show(adsID, this);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print(" interstitial clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print(" interstitial shown complete");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print(" interstitial shown failed");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print(" interstitial shown started");
    }
}

