using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestDatastore : MonoBehaviour
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
    public IEnumerator checkMainSceneItems()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnPushGameObj = GameObject.Find("Pushnotification");
        var btnFilestoreGameObj = GameObject.Find("File store");
        var btnUserMgmGameObj = GameObject.Find("User management");
        var btnScriptGameObj = GameObject.Find("Script");
        
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        var btnPush = btnPushGameObj.GetComponent<Button>();
        var btnFilestore = btnFilestoreGameObj.GetComponent<Button>();
        var btnUserMgm = btnUserMgmGameObj.GetComponent<Button>();
        var btnScript = btnScriptGameObj.GetComponent<Button>();
        Assert.NotNull(btnDatastore);
        Assert.NotNull(btnPush);
        Assert.NotNull(btnFilestore);
        Assert.NotNull(btnUserMgm);
        Assert.NotNull(btnScript);
        yield return new WaitForSeconds(1);
    }

    [UnityTest]
    public IEnumerator testQuickStart()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnGameObj = GameObject.Find("Quick Start");
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
    public IEnumerator testSave()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnGameObj = GameObject.Find("Save");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testGetObj()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(1);
        
        var btnSaveGameObj = GameObject.Find("Save");
        var btnSave = btnSaveGameObj.GetComponent<Button>();
        btnSave.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnGameObj = GameObject.Find("Get Object");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testUpdateObj()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(3);
        
        var btnSaveGameObj = GameObject.Find("Save");
        var btnSave = btnSaveGameObj.GetComponent<Button>();
        btnSave.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnGameObj = GameObject.Find("Update Object");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testDeleteObj()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(1);

        var btnSaveGameObj = GameObject.Find("Save");
        var btnSave = btnSaveGameObj.GetComponent<Button>();
        btnSave.onClick.Invoke();

        yield return new WaitForSeconds(3);
        
        var btnGameObj = GameObject.Find("Update Object");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testQuery()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(1);

        var btnGameObj = GameObject.Find("Query Ranking");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testACL()
    {
        var btnDatastoreGameObj = GameObject.Find("Datastore");
        var btnDatastore = btnDatastoreGameObj.GetComponent<Button>();
        btnDatastore.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnGameObj = GameObject.Find("ACL");
        var btn = btnGameObj.GetComponent<Button>();
        Assert.NotNull(btn);
        btn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }
}
