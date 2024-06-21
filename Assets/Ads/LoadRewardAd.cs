using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class LoadRewardAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string AppleID;
    public string AndroidID;
    public AdsKind adsKind;
    public gameManager gameManager;
    public FirstScene Scene;
    public Text pointtext, collecttex;

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
        Advertisement.Load(adsID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {

        if (placementId.Equals(adsID))
        {
            print(" interstitial loaded");
            ShowAd();
        }
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
        Scene.close_button();
        Scene.setbutton();
         
        if (placementId.Equals(adsID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            switch (adsKind)
            {
                case AdsKind.turboUpgrade:

                    gameManager.buyjetpack(true);
                    
                    break;
                case AdsKind.EngineUpgrade:

                    gameManager.buyEngine(true);
                     
                    break;
                case AdsKind.DoubleCoin:
                    
                    int s = int.Parse(pointtext.text);
                    s = s * 2;
                    collecttex.text = s.ToString();

                    PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + (s / 2));
                    Move m = new Move();
                    m.checkcoin();
                    
                    break;
            }
        }
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
public enum AdsKind
{
    turboUpgrade,
    EngineUpgrade,
    DoubleCoin
}
