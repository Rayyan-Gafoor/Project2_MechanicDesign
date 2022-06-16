using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScript : MonoBehaviour
{
  
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name== "ValveMC")
        {
            SceneManager.LoadScene(sceneName: "Level 2");
        }
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(sceneName: "");
    }
    
}
