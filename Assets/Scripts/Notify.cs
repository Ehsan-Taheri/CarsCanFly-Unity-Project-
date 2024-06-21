using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.SimpleAndroidNotifications;

public class Notify : MonoBehaviour
{
    NotificationExample n = new NotificationExample();
     
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            print("application is" + focus);
        }
         
    }
}