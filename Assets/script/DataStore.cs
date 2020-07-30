using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	string lastedObjectID;

	public void QuickStart()
	{
		// クラスのNCMBObjectを作成
		NCMBObject testClass = new NCMBObject("TestClass");

		// オブジェクトに値を設定

		testClass["message"] = "Hello, NCMB!";
		// データストアへの登録
		testClass.SaveAsync((NCMBException e) => {
			if (e != null)
			{
				//エラー処理
				Debug.LogError(e);
			}
			else
			{
				//成功時の処理
				lastedObjectID = testClass.ObjectId;
				Debug.Log("Quick start success ");
			}
		});
	}

	public void SaveObject()
	{
		NCMBObject obj = new NCMBObject("TestClass");
		obj.Add("Name", "Unity");
		obj.SaveAsync((NCMBException e) => {
			if (e != null)
			{
				//エラー処理
				Debug.LogError(e);
			}
			else
			{
				//成功時の処理
				lastedObjectID = obj.ObjectId;
				Debug.Log("Save object success " + lastedObjectID);
			}
		});
	}

	public void GetObject()
	{
		if (lastedObjectID != null)
		{
			NCMBObject obj2 = new NCMBObject("TestClass");
			obj2.ObjectId = lastedObjectID;
			obj2.FetchAsync((NCMBException e) =>
			{
				if (e != null)
				{
					//エラー処理
					Debug.LogError(e);
				}
				else
				{
					//成功時の処理
					Debug.Log("Get object success " + lastedObjectID);
				}
			});
		}
	}

	public void UpdateObject()
	{
		if (lastedObjectID != null)
		{
			NCMBObject obj2 = new NCMBObject("TestClass");
			obj2.ObjectId = lastedObjectID;
			obj2.FetchAsync((NCMBException e) => {
				if (e != null)
				{
					//エラー処理
					Debug.LogError(e);
				}
				else
				{
					obj2["message"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					obj2.SaveAsync((NCMBException e2) => {
						if (e2 != null)
						{
							//エラー処理
							Debug.LogError(e2);
						}
						else
						{
							//成功時の処理
							lastedObjectID = obj2.ObjectId;
							Debug.Log("Update object success " + lastedObjectID);
						}
					});
				}
			});
		}
		
	}

	public void DeleteObject()
	{
		if (lastedObjectID != null)
		{
			NCMBObject obj2 = new NCMBObject("TestClass");
			obj2.ObjectId = lastedObjectID;
			obj2.FetchAsync((NCMBException e) =>
			{
				if (e != null)
				{
					//エラー処理
					Debug.LogError(e);
				}
				else
				{
					//成功時の処理

					obj2.DeleteAsync();
					lastedObjectID = null;
					Debug.Log("Delete object success " + lastedObjectID);
				}
			});
		}
	}

	public void QueryObject()
	{
		//QueryTestを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("TestClass");
		query.FindAsync((List<NCMBObject> objList, NCMBException e) => {
			if (e != null)
			{
				//検索失敗時の処理
				Debug.LogError(e);
			}
			else
			{
				//Scoreが7のオブジェクトを出力
				foreach (NCMBObject obj in objList)
				{
					Debug.Log("Query count: " + objList.Count);
				}
			}
		});
	}

	public void ACLObject()
	{

		//NCMBACLオブジェクトを作成
		NCMBACL acl = new NCMBACL();

		//読み込み権限を全開放
		acl.PublicReadAccess = true;

		//書き込み権限を全開放
		acl.PublicWriteAccess = true;

		NCMBObject obj = new NCMBObject("TestClass");
		obj.Add("Name", "Unity");
		obj.Add("message", "ACL");
		obj.ACL = acl;
		obj.SaveAsync((NCMBException e) => {
			if (e != null)
			{
				//エラー処理
				Debug.LogError(e);
			}
			else
			{
				//成功時の処理
				lastedObjectID = obj.ObjectId;
				Debug.Log("Save object with ACL success " + lastedObjectID);
			}
		});
	}

}
