using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public int flag = 0;
    public GameObject temp__letter;
    public bool can__read = false;
    private void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("intrigger");
        if (other.tag == "Player")
        {
            can__read = true;
            if (Input.GetKeyDown(KeyCode.E) && flag==0)
            {
                Debug.Log("reading");
                temp__letter.SetActive(true);
                flag = 1;
            }
            else if(Input.GetKeyDown(KeyCode.E) && flag == 1)
            {
                temp__letter.SetActive(false);
                flag = 0;
            }

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        can__read = true;
        if (other.tag == "Player")
        {
            temp__letter.SetActive(false);
            flag = 0;
        }
    }
}
