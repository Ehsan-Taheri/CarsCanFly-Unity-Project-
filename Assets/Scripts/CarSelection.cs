using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;

public class CarSelection : MonoBehaviour
{
    public GameObject Buybutton;
    public GameObject SelectButton;

    private int cur_car;
    public Transform carsPanel;
    public AudioSource ac;
    public Text priceTxt, gem_text;
    public Dictionary<GameObject, int> CarValue = new Dictionary<GameObject, int>();
    public List<GameObject> Cars;
    public List<int> Prices;

    int coin;
    public AudioClip change, select, buyclip;

    // Use this for initialization
    private void Awake()
    {

         CarValue = Cars.Zip(Prices, (key, value) => new { Key = key, Value = value })
                                                    .ToDictionary(pair => pair.Key, pair => pair.Value);


    }
    void Start()
    {
        cur_car = PlayerPrefs.GetInt("carindx");
        carsPanel.GetChild(cur_car).gameObject.SetActive(true);
       
        print(CarValue.Count);
    }

    void GetCoin()
    {
        coin = PlayerPrefs.GetInt("gem");

    }

    public void ChangeCar(int indx)
    {
        ac.clip = change;
        ac.Play();

        CarValue.ElementAt(cur_car).Key.SetActive(false);
        cur_car += indx;
        print(cur_car);
        if (cur_car < 0)
        {
            cur_car = CarValue.Count-1;
        }
        if (cur_car>CarValue.Count-1)
        {
            cur_car = 0;
        }
        CarValue.ElementAt(cur_car).Key.SetActive(true);
        priceTxt.text = CarValue.ElementAt(cur_car).Value.ToString();
        checkBuy(cur_car);
         


    }

    public void Selecting()
    {
        ac.clip = select;
        ac.Play();
        PlayerPrefs.SetInt("carindx", cur_car);
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");

    }

    public void buy()
    {

        GetCoin();
        if (coin >= CarValue.ElementAt(cur_car).Value)
        {
            ac.clip = buyclip;
            ac.Play();
            PlayerPrefs.SetInt("lock" + cur_car.ToString(), 1);
            int newcoin = coin - CarValue.ElementAt(cur_car).Value;
            PlayerPrefs.SetInt("gem", newcoin);
            gem_text.text = PlayerPrefs.GetInt("gem").ToString();
            checkBuy(cur_car);
        }
    }

    public bool checkBuy(int index)
    {
        print("Check index" + index);
        int check = PlayerPrefs.GetInt("lock" + index.ToString());
        if (check == 0)
        {
            Buybutton.SetActive(true);
            SelectButton.SetActive(false);
            
            return true;
        }
        else
        {
            Buybutton.SetActive(false);
            SelectButton.SetActive(true);
            return false;
        }
    }

}

