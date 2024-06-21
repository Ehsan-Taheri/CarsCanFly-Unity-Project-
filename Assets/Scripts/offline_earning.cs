using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;
using UnityEngine.SceneManagement;

public class offline_earning : MonoBehaviour
{
    const float timetoearn = 3600000f;
    public ulong lastplay;

    offline_earning instance;
    // Start is called before the first frame update
    readonly NotificationExample n = new();
    
    private void Awake()
    {
        instance = FindAnyObjectByType<offline_earning>();
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
       else 
        {
            instance = this;
           
            if (instance == null)
                
            DontDestroyOnLoad(this);
        }
        

        lastplay = ulong.Parse(PlayerPrefs.GetString("lastplay", "0"));
        if (lastplay != 0)
        {
            n.CancelAll();
            if (Check_earning())
            {
                n.ScheduleNormal();
                PlayerPrefs.SetInt("offline", 1);
            }
        }
        lastplay = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("lastplay", lastplay.ToString());



    }


    public bool Check_earning()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastplay);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondleft = (float)(timetoearn - m) / 1000.0f;
        print("Second left "+secondleft);
        if (secondleft < 0)                  
            return true;
         
            return false;
    }
    
}
