using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UserManagement : MonoBehaviour
{
    public InputField user;
    public InputField password;
    public InputField roleName;
    private bool isLogedIn = false;
    // Start is called before the first frame update
    void Start()
    {
        if (NCMBUser.CurrentUser != null && NCMBUser.CurrentUser.ObjectId.Length > 0)
        {
            isLogedIn = true;
            if (NCMBUser.CurrentUser.UserName.Length > 0)
            {
                user.text = NCMBUser.CurrentUser.UserName;

            } else
            {
                user.text = NCMBUser.CurrentUser.Email;
            }
        } else
        {
            isLogedIn = false;
        }

        SetActive();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SetActive()
    {
        GameObject.Find("LoginOrSignUp").SetActive(!isLogedIn);
        GameObject.Find("Password").SetActive(!isLogedIn);
        GameObject.Find("LogOut").SetActive(isLogedIn);
        GameObject.Find("AddMemberToRole").SetActive(isLogedIn);
        GameObject.Find("RemoveMemberFromRole").SetActive(isLogedIn);
        GameObject.Find("AddChildRole").SetActive(isLogedIn);
    }

    public bool IsEmail(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public void LoginOrSignUp()
    {
        if (user.text.Length > 0 && password.text.Length > 0)
        {

            if (IsEmail(user.text))
            {
                NCMBUser.LogInWithMailAddressAsync(user.text, password.text, (NCMBException e) => {
                    if (e != null) 
                    {
                        if (e.ErrorCode.CompareTo("E400003") == 0)
                        {
                            SignUp();
                        } else
                        {
                            Debug.Log("ログインに失敗: " + e.ErrorMessage);

                        }
                        

                    } 
                    else
                    {
                        isLogedIn = true;
                        Debug.Log("ログインに成功！");
                    }
                    SetActive();
                });

            } else
            {
                // ユーザー名とパスワードでログイン
                NCMBUser.LogInAsync(user.text, password.text, (NCMBException e) => {
                    if (e != null)
                    {
                        if (e.ErrorCode.CompareTo("E400003") == 0)
                        {
                            SignUp();
                        }
                        else
                        {
                            Debug.Log("ログインに失敗: " + e.ErrorMessage);

                        }
                    }
                    else
                    {
                        isLogedIn = true;
                        Debug.Log("ログインに成功！");
                    }
                    SetActive();
                });
            }
            
        }
    }

    public void SignUp()
    {
        //NCMBUserのインスタンス作成 
        NCMBUser us = new NCMBUser();
        //ユーザ名とパスワードの設定
        if (IsEmail(user.text))
        {
            us.Email = user.text;
        } else
        {
            us.UserName = user.text;
        }

        us.Password = password.text;

        //会員登録を行う
        us.SignUpAsync((NCMBException e) => {
            if (e != null)
            {
                Debug.Log("新規登録に失敗: " + e.ErrorMessage);
            }
            else
            {
                isLogedIn = true;
                Debug.Log("新規登録に成功");
            }
            SetActive();
        });
    }

    public void LogOut()
    {
        if (isLogedIn)
        {
            NCMBUser.LogOutAsync();
            isLogedIn = false;
            SetActive();
        }
    }

    public void RequestEmail()
    {
        if (IsEmail(user.text))
        {
            NCMBUser.RequestAuthenticationMailAsync(user.text, (NCMBException e) => {
                if (e != null)
                {
                    UnityEngine.Debug.Log("新規登録に失敗: " + e.ErrorMessage);
                }
                else
                {
                    UnityEngine.Debug.Log("新規登録に成功");
                }
            });
        }
        
    }

    public void AddToRole()
    {
        if (isLogedIn)
        {
            NCMBRole.GetQuery().WhereEqualTo("roleName", roleName.text).FindAsync((roleList, error) =>
            {
                if (roleList.Count > 0)
                {
                    NCMBRole role = roleList[0];
                    if (role != null)
                    {
                        role.Users.Add(NCMBUser.CurrentUser);
                        role.SaveAsync();
                    }
                }

            });
        }
    }

    public void RemoveFromRole()
    {
        if (isLogedIn)
        {
            NCMBRole.GetQuery().WhereEqualTo("roleName", roleName.text).FindAsync((roleList, error) =>
            {
                if (roleList.Count > 0)
                {
                    NCMBRole role = roleList[0];
                    if (role != null)
                    {
                        role.Users.Remove(NCMBUser.CurrentUser);
                        role.SaveAsync();
                    }
                }

            });
        }
    }


    public void AddToChildRole()
    {
        if (isLogedIn)
        {
            string childRoleName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            NCMBRole childRole = new NCMBRole(childRoleName);
            childRole.SaveAsync((NCMBException saveError) => {
                if (saveError != null)
                {
                    // エラー処理
                }
                else
                {
                    // 保存済みのロールに作成したロールを追加
                    NCMBRole.GetQuery().WhereEqualTo("roleName", roleName.text).FindAsync((roleList, findError) => {
                        if (findError != null)
                        {
                            // エラー処理
                        }
                        else
                        {
                            if (roleList.Count > 0)
                            {
                                NCMBRole bronzeRole = roleList[0];
                                if (bronzeRole != null)
                                {
                                    bronzeRole.Roles.Add(childRole);
                                    bronzeRole.SaveAsync();
                                }
                            }
                            
                        }
                    });
                }
            });
        }
    }


}
