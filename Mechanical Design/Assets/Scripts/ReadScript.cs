using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public int flag = 0;
    public GameObject temp__letter;
    public GameObject pickup__ui;
    public bool can__read = false;
    private void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("intrigger");
        if (other.tag == "Player")
        {
            pickup__ui.SetActive(true);
               can__read = true;
            if (Input.GetKey(KeyCode.E) && flag==0)
            {
                StartCoroutine(read());
            }
            else if(Input.GetKey(KeyCode.E) && flag == 1)
            {
                StartCoroutine(close());
            }

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        can__read = true;
        pickup__ui.SetActive(false);
        if (other.tag == "Player")
        {
            temp__letter.SetActive(false);
            flag = 0;
        }
    }
    IEnumerator read()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("reading");
        temp__letter.SetActive(true);
        flag = 1;
        
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("close letter");
        temp__letter.SetActive(false);
        flag = 0;
       
    }
}
