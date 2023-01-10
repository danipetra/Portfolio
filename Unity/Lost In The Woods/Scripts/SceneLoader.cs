using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //CheckEscCommand(); PC Only
    }

    public void LoadScene(string name)
    {
        Debug.Log("loadlevel request for: " + name);
        resetTimeScale();
        SceneManager.LoadScene(name);
        
    }
    public void ReloadScene()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScene);
        Debug.Log("Reloading scene" + CurrentScene);
    }

    public void CheckEscCommand()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Request to Quit");
            Application.Quit();
        }
    }

    private void resetTimeScale()
    {
        if(Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
    }
   
}
