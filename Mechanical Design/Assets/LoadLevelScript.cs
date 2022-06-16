using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScript : MonoBehaviour
{

    public GameObject controls;
    public GameObject credits;

    private void Start()
    {
        if (controls == null)
        {
            return;
        }
        if (credits == null)
        {
            return;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName: "Title");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name== "ValveMC")
        {
            SceneManager.LoadScene(sceneName: "Level 2");
        }
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void back()
    {
        controls.SetActive(false);
        credits.SetActive(false);
    }
    public void credit()
    {
       // controls.SetActive(false);
        credits.SetActive(true);
    }
    public void control()
    {
        controls.SetActive(true);
        //credits.SetActive(false);
    }

}
