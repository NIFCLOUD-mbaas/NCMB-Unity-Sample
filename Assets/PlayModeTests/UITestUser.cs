using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using NCMB;

public class UITestUser : MonoBehaviour
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
    public IEnumerator testLogin()
    {
        NCMBUser.LogOutAsync((NCMBException e) => {
            UITestSettings.CallbackFlag = true;
        });
        yield return UITestSettings.AwaitAsync();
        var btnUserMngGameObj = GameObject.Find("User management");
        var btnUserMng = btnUserMngGameObj.GetComponent<Button>();
        btnUserMng.onClick.Invoke();

        yield return new WaitForSeconds(1);

        var ifUsernameGameObj = GameObject.Find("User");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("LoginOrSignUp");
        var btnLogIn = btnLogInGameObject.GetComponent<Button>();
        btnLogIn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnLogOutGameObject = GameObject.Find("LogOut");
        var btnLogOut = btnLogOutGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogOutGameObject);
    }

    [UnityTest]
    public IEnumerator testLogout()
    {
        NCMBUser.LogOutAsync((NCMBException e) => {
            UITestSettings.CallbackFlag = true;
        });
        yield return UITestSettings.AwaitAsync();
        var btnUserMngGameObj = GameObject.Find("User management");
        var btnUserMng = btnUserMngGameObj.GetComponent<Button>();
        btnUserMng.onClick.Invoke();

        yield return new WaitForSeconds(1);

        var ifUsernameGameObj = GameObject.Find("User");
        var ifUsername = ifUsernameGameObj.GetComponent<InputField>();

        var ifPasswordGameObj = GameObject.Find("Password");
        var ifPassword = ifPasswordGameObj.GetComponent<InputField>();

        ifUsername.text = "testuser";
        ifPassword.text = "123456";

        var btnLogInGameObject = GameObject.Find("LoginOrSignUp");
        var btnLogIn = btnLogInGameObject.GetComponent<Button>();
        btnLogIn.onClick.Invoke();

        yield return new WaitForSeconds(3);

        var btnLogOutGameObject = GameObject.Find("LogOut");
        var btnLogOut = btnLogOutGameObject.GetComponent<Button>();
        Assert.NotNull(btnLogOutGameObject);
        btnLogOut.onClick.Invoke();

        yield return new WaitForSeconds(3);
        var userGameObj = GameObject.Find("User management");
        Assert.NotNull(userGameObj);
    }

    
}
