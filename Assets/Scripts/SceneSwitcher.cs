using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public string gameSceneName;
   
   public void LoadGameScene()
   {
      SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
   }
}
