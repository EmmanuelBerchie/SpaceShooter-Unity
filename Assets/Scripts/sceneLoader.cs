using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    //public void to to avoid a return type 
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Load next scene by adding 1 one to the current scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



    public void LoadStartScene()
    {

        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
