using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectMenu(GameObject obj)
    {
        PlayerPrefs.SetString("LastedScene", SceneManager.GetActiveScene().name);
        string tag = obj.tag;
        SceneManager.LoadScene(tag);
    }

    public void ExitScreen()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastedScene"));

    }
}
