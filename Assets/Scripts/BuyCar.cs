using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCar : MonoBehaviour
{
    private int carindex;
    public int[] money;

    public GameObject Buybutton;
    public GameObject SelectButton;

    public Text NeedMoney;
    public int coin;

    public Text gem_text;
    public AudioSource ac;
    public AudioClip buyclip;
    // Start is called before the first frame update
    void Start()
    {
        gem_text.text = PlayerPrefs.GetInt("gem").ToString();
        carindex = PlayerPrefs.GetInt("carindx");
        PlayerPrefs.SetInt("lock0", 1);
        checkBuy(0);

    }

    void GetCoin()
    {
        coin = PlayerPrefs.GetInt("gem");

    }
  
   public bool checkBuy(int index)
    {
        print("Check index" + index);
        int check = PlayerPrefs.GetInt("lock" + index.ToString());
        if(check == 0)
        {
            Buybutton.SetActive(true);
            SelectButton.SetActive(false);
            NeedMoney.text = money[index].ToString();
            return true;
        }
        else
        {
            Buybutton.SetActive(false);
            SelectButton.SetActive(true);
            return false;
        }
    }

    public void buy()
    {

        GetCoin();
        if (coin >= money[carindex])
        {
            ac.clip = buyclip;
            ac.Play();
            PlayerPrefs.SetInt("lock" + carindex.ToString(), 1);
            int newcoin = coin - money[carindex];
            PlayerPrefs.SetInt("gem", newcoin);
            gem_text.text = PlayerPrefs.GetInt("gem").ToString();
           // checkBuy();
        }
    }
}
