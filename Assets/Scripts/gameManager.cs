using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class gameManager : MonoBehaviour
{

    public GameObject tutorial_panel, gem;
    public GameObject turbouvideo, enginevideo;
    GameObject player;
    public AudioSource ac;
    public AudioClip click, collect;
    public Transform cars;
    int count, indx;
    public GameObject Effects;
    [Header("Button")]
    public GameObject car;
    public GameObject engine, turbo, highscore, money, earningb,moreGame;
    public Text collected, coin;
    public GameObject coll_pan;




    void Start()
    {
        gem.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("gem").ToString();
        count = cars.childCount;
        indx = PlayerPrefs.GetInt("carindx");
        next_car();
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("offline") == 1)
        {
            collected.text =  PlayerPrefs.GetInt("earning").ToString();
            coll_pan.SetActive(true);
        }
    }


    
    public void restart()
    {
        ac.clip = collect;
        ac.Play();
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().Restart();
        
    }

    public void shif()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().Button_clck();
        engine.SetActive(false);
        turbo.SetActive(false);
        highscore.SetActive(false);
        money.SetActive(false);
        car.SetActive(false);
        earningb.SetActive(false);
        turbouvideo.SetActive(false);
        enginevideo.SetActive(false);
        gem.SetActive(false);
        moreGame.SetActive(false);
    }
    public void turbo_down()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().turbtn();
    }
    public void turbo_up()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().upbtn();
    }
    public void buyEngine(bool free)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().engine_up(free);
        ac.clip = click;
        ac.Play();
    }
    public void buyjetpack(bool free)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().turbo_up(free);
        ac.clip = click;
        ac.Play();
    }
    public void earning()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Move>().earning();
        ac.clip = click;
        ac.Play();
    }
    public void sound()
    {
        ac.clip = collect;
        ac.Play();
    }
    public void selectcar()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("select car");
        ac.clip = collect;
        ac.Play();
    }
    public void next_car()
    {


        cars.GetChild(indx).gameObject.SetActive(true);


        PlayerPrefs.SetInt("carindx", indx);
        var m = GameObject.Find("Main Camera");
        m.GetComponent<Camera_follow>().set_target();


    }
    public void exitpanel()
    {
        PlayerPrefs.SetInt("offline", 0);

        coll_pan.SetActive(false);
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + PlayerPrefs.GetInt("earning"));
        coin.text = PlayerPrefs.GetInt("coin").ToString();
        Move m = FindAnyObjectByType<Move>();
        m.checkcoin();
    }
    public static int index = 0;
    public void tut_next()
    {
        tutorial_panel.SetActive(false);

        switch (index)
        {
            case 0:

                shif();
                Time.timeScale = 1;
                tutorial_panel.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                break;
            case 1:

                Time.timeScale = 1;
                break;
            case 2:
                shif();
                Time.timeScale = 1;
                break;
            case 3:

                Time.timeScale = 1;
                break;
            case 4:
                shif();
                tutorial_panel.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                tutorial_panel.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                Time.timeScale = 1;
                break;
            case 5:
                
                Time.timeScale = 1;
                break;

        }
        index++;
    }
}
