using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAd : MonoBehaviour
{
   public LoadInterstitial interstitial;
    [Range(0,9)]
    public int thereshould;
    private void OnEnable()
    {
        StartCoroutine(RunAd());
       
    }
    IEnumerator RunAd()
    {
        yield return new WaitForEndOfFrame();
        int pickedNum = Random.Range(0, 10);
        print("pickednumber" + pickedNum);
        if (pickedNum < thereshould)
            interstitial.LoadAD();
    }
}
