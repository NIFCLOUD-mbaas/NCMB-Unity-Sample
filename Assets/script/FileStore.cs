using NCMB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileStore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string lastedFileName = null;

    public void UploadFile()
    {
        string dateString = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Content : " + dateString);
        NCMBFile file = new NCMBFile(dateString + ".txt", data);
        file.SaveAsync((NCMBException error) => {
            if (error != null)
            {
                // 失敗
                Debug.LogError(error);
            }
            else
            {
                // 成功
                lastedFileName = dateString + ".txt";
                Debug.Log("Upload file success " + lastedFileName);
            }

           
        });
    }


    public void GetFile()
    {
        if (lastedFileName != null)
        {
            NCMBFile file = new NCMBFile(lastedFileName);
            file.FetchAsync((byte[] fileData, NCMBException error) => {
                if (error != null)
                {
                    // 失敗
                    Debug.LogError(error);
                }
                else
                {
                    // 成功
                    Debug.Log("Get file success:  " + System.Text.Encoding.Default.GetString(fileData));
                }
            });
        }
    }

    public void DeleteFile()
    {
        if (lastedFileName != null)
        {
            NCMBFile file = new NCMBFile(lastedFileName);
            file.DeleteAsync();
            lastedFileName = null;
        }
    }

}
