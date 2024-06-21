using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using System;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{


    public Button RateUsBtn;
    public Button goToGame;

    private void Awake()
    {


        try
        {
            goToGame.onClick.AddListener(GoToGame);
            RateUsBtn.onClick.AddListener(OpenRatePanel);
        }
        catch
        {

        }
    }

    private void GoToGame()
    {
        SceneManager.LoadScene("main");
    }

    public void OpenRatePanel()
    {
        Application.OpenURL("myket://comment?id=com.blindowl.CarsCanFly");
        PlayerPrefs.SetInt("rate", 1);

    }
}

