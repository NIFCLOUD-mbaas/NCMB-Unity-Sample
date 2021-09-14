using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestPush : MonoBehaviour
{
    [SetUp]
    public void init()
    {
        SceneManager.LoadScene("Main");
        UITestSettings.CallbackFlag = false;
    }

    [TearDown]
    public void TearDown()
    {

    }

    [UnityTest]
    public IEnumerator testPush()
    {
        yield return new WaitForSeconds(1);
        var btnPushGameObj = GameObject.Find("Pushnotification");
        var btnPush = btnPushGameObj.GetComponent<Button>();
        btnPush.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnSendPushGameObj = GameObject.Find("Send Push");
        var btnSendPush = btnSendPushGameObj.GetComponent<Button>();
        Assert.NotNull(btnSendPush);
        btnSendPush.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvTitleGameObj = GameObject.Find("Result");
        var tvResult = tvTitleGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testRichPush()
    {
        yield return new WaitForSeconds(1);

        var btnPushGameObj = GameObject.Find("Pushnotification");
        var btnPush = btnPushGameObj.GetComponent<Button>();
        btnPush.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnSendPushGameObj = GameObject.Find("Send Rich Push");
        var btnSendPush = btnSendPushGameObj.GetComponent<Button>();
        Assert.NotNull(btnSendPush);
        btnSendPush.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }
}
