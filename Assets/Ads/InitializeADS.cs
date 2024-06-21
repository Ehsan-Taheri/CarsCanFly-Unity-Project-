using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class InitializeADS : MonoBehaviour,IUnityAdsInitializationListener
{
    public string AppleID;
    public string AndroidID;
    public bool isTestGame;

    string adsID;

    private void Awake()
    {
        InitializeAD();
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Is initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Not initialized");
    }

    void InitializeAD()
    {
#if UNITY_IOS
adsID= AppleID;
#elif UNITY_ANDROID
        adsID = AndroidID;
#elif UNITY_EDITOR
adsID = AndroidID;
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(adsID, isTestGame, this);
            print("initializing"+adsID);
        }

    }
}
