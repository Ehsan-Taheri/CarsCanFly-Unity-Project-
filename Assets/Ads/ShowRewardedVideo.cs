using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class ShowRewardedVideo : MonoBehaviour
{
    [SerializeField] LoadRewardAd rewardAd;
    public AdsKind AdsKind;

     public void LoadRewardAd( )
    {
        print("Load ad in turbo upgrade");

        rewardAd.adsKind =AdsKind;
        rewardAd.LoadAD();
      
        
     
   
    }
    
  
 
}

