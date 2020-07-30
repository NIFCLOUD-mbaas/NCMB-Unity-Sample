using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendPush()
    {
        NCMBPush push = new NCMBPush();
        push.Title = "Unity normal notification";
        push.Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        push.ContentAvailable = true;
        push.BadgeIncrementFlag = false;
        push.ImmediateDeliveryFlag = true;
        push.SendPush();
    }
    public void SendRichPush()
    {
        NCMBPush push = new NCMBPush();
        push.Title = "Unity rich notification";
        push.Message = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        push.ContentAvailable = true;
        push.BadgeIncrementFlag = false;
        push.ImmediateDeliveryFlag = true;
        push.RichUrl = "https://google.com";
        push.SendPush();
    }
}
