using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestScript : MonoBehaviour
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
    public IEnumerator testGetScript()
    {
        yield return new WaitForSeconds(1);
        var btnScriptGameObj = GameObject.Find("Script");
        var btnScript = btnScriptGameObj.GetComponent<Button>();
        btnScript.onClick.Invoke();
        
        yield return new WaitForSeconds(3);
        var btnGameObj = GameObject.Find("Script GET");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvTitleGameObj = GameObject.Find("Result");
        var tvResult = tvTitleGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testPostScript()
    {
        yield return new WaitForSeconds(1);
        var btnScriptGameObj = GameObject.Find("Script");
        var btnScript = btnScriptGameObj.GetComponent<Button>();
        btnScript.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnGameObj = GameObject.Find("Script POST");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvTitleGameObj = GameObject.Find("Result");
        var tvResult = tvTitleGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testDeleteScript()
    {
        yield return new WaitForSeconds(1);
        var btnScriptGameObj = GameObject.Find("Script");
        var btnScript = btnScriptGameObj.GetComponent<Button>();
        btnScript.onClick.Invoke();

        yield return new WaitForSeconds(2);

        var btnScritpPostGameObj = GameObject.Find("Script POST");
        var btnScritpPost = btnScritpPostGameObj.GetComponent<Button>();
        Assert.NotNull(btnScritpPost);
        btnScritpPost.onClick.Invoke();
        
        yield return new WaitForSeconds(3);
        
        var btnGameObj = GameObject.Find("Script DEL");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvTitleGameObj = GameObject.Find("Result");
        var tvResult = tvTitleGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }
}
