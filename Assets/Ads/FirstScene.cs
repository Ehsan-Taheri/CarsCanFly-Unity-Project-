using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstScene : MonoBehaviour
{
    public GameObject turbouvideo, enginevideo, turbo_upgrade, engine_upgrade;

    void Start()
    {
        if (PlayerPrefs.GetInt("firstplay") != 0)
        {
            int rand = Random.Range(0, 8);
            if (rand == 1)
            {
                enginevideo.SetActive(true);
                engine_upgrade.SetActive(false);

            }
            if (rand == 0)
            {
                turbouvideo.SetActive(true);
                turbo_upgrade.SetActive(false);

            }
        }
    }

    public void setbutton()
    {
        turbouvideo.SetActive(false);
        turbo_upgrade.SetActive(true);
        enginevideo.SetActive(false);
        engine_upgrade.SetActive(true);

    }

    public void close_button()
    {
        turbouvideo.SetActive(false);
        turbo_upgrade.SetActive(false);
        enginevideo.SetActive(false);
        engine_upgrade.SetActive(false);

    }

}