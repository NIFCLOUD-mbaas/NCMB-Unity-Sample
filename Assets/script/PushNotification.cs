using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushNotification : MonoBehaviour
{
    public Text result;
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
        push.SendPush((NCMBException error) => {
            if (error != null)
            {
                result.text = (string)error.ErrorMessage;
            }
            else
            {
                result.text = "Success";
            }
        });
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
        push.SendPush((NCMBException error) => {
            if (error != null)
            {
                result.text = (string)error.ErrorMessage;
            }
            else
            {
                result.text = "Success";
            }
        });
    }
}
