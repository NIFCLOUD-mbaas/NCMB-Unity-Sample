using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestFilestore : MonoBehaviour
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
    public IEnumerator testUploadFile()
    {
        var btnFilestoreGameObj = GameObject.Find("File store");
        var btnFilestore = btnFilestoreGameObj.GetComponent<Button>();
        btnFilestore.onClick.Invoke();

        yield return new WaitForSeconds(2);
        
        var btnUploadGameObj = GameObject.Find("Upload");
        var btnUpload = btnUploadGameObj.GetComponent<Button>();
        Assert.NotNull(btnUpload);
        btnUpload.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvTitleGameObj = GameObject.Find("Result");
        var tvResult = tvTitleGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testGetFile()
    {
        var btnFilestoreGameObj = GameObject.Find("File store");
        var btnFilestore = btnFilestoreGameObj.GetComponent<Button>();
        btnFilestore.onClick.Invoke();

        yield return new WaitForSeconds(2);

        var btnUploadGameObj = GameObject.Find("Upload");
        var btnUpload = btnUploadGameObj.GetComponent<Button>();
        Assert.NotNull(btnUpload);
        btnUpload.onClick.Invoke();

        yield return new WaitForSeconds(3);
        
        var btnGetFileGameObj = GameObject.Find("Get File");
        var btnGetFile = btnGetFileGameObj.GetComponent<Button>();
        Assert.NotNull(btnGetFile);
        btnGetFile.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }

    [UnityTest]
    public IEnumerator testDeleteFile()
    {
        var btnFilestoreGameObj = GameObject.Find("File store");
        var btnFilestore = btnFilestoreGameObj.GetComponent<Button>();
        btnFilestore.onClick.Invoke();

        yield return new WaitForSeconds(2);
        
        var btnUploadGameObj = GameObject.Find("Upload");
        var btnUpload = btnUploadGameObj.GetComponent<Button>();
        Assert.NotNull(btnUpload);
        btnUpload.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnDeleteGameObj = GameObject.Find("Delete");
        var btnDelete = btnDeleteGameObj.GetComponent<Button>();
        Assert.NotNull(btnDelete);
        btnDelete.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var tvResultGameObj = GameObject.Find("Result");
        var tvResult = tvResultGameObj.GetComponent<Text>();
        var result = tvResult.text;
        Assert.True(result.Contains("Success"));
    }
}
