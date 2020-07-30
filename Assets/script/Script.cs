using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [Serializable]
    public class TestClass
    {
        public string objectId;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string lastPostObjectId = null;
    public void ScriptGet()
    {
        NCMBScript script = new NCMBScript("script_get.js", NCMBScript.MethodType.GET);
        script.ExecuteAsync(null, null, null, (byte[] result, NCMBException e) => {
            if (e != null)
            {
                // 失敗
                Debug.LogError(e);
            }
            else
            {
                // 成功
                Debug.Log("Script get run successful ");
            }
        });

    }

    public void ScriptPost()
    {
        NCMBScript script = new NCMBScript("script_post.js", NCMBScript.MethodType.POST);
        Dictionary<string, object> body = new Dictionary<string, object>() { { "message", DateTime.Now.ToString("yyyy_MM_dd_HHmmss") } };
        script.ExecuteAsync(null, body, null, (byte[] result, NCMBException e) => {
            if (e != null)
            {
                // 失敗
                Debug.LogError(e);
            }
            else
            {
                lastPostObjectId = JsonUtility.FromJson<TestClass>(System.Text.Encoding.UTF8.GetString(result)).objectId;

                // 成功
                Debug.Log("Script post run successful ");
            }
        });

    }

    public void ScriptDelete()
    {
        if (lastPostObjectId != null) {
            NCMBScript script = new NCMBScript("script_delete.js", NCMBScript.MethodType.DELETE);
            Dictionary<string, object> query = new Dictionary<string, object>() { { "id", lastPostObjectId } };
            script.ExecuteAsync(null, null, query, (byte[] result, NCMBException e) => {
                if (e != null)
                {
                    // 失敗
                    Debug.LogError(e);
                }
                else
                {
                    lastPostObjectId = null;
                    // 成功
                    Debug.Log("Script delete run successful ");
                }
            });
        }
    }
}
