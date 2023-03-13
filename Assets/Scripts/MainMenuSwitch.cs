using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenu", 5f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
}
