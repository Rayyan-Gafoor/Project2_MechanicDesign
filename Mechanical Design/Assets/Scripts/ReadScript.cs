using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public int flag = 0;
    public int flag__tut=0;
    public GameObject temp__letter;
    public GameObject pickup__ui;
    public GameObject tutorial;
    public bool can__read = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(close__tutorial());
        }
        if (Input.GetKeyDown(KeyCode.E) && flag == 1)
        {
            StartCoroutine(close());
        }
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
       //can__read = true;
        pickup__ui.SetActive(false);
        /*if (other.tag == "Player")
        {
            temp__letter.SetActive(false);
            flag = 0;
            StartCoroutine(display__tutorial());
        }*/
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
        StartCoroutine(display__tutorial());
        flag = 0;
       
    }
    IEnumerator display__tutorial()
    {
        yield return new WaitForSeconds(0.5f);
        tutorial.SetActive(true);
        flag__tut =1;
        yield return new WaitForSeconds(5);
        StartCoroutine(close__tutorial());
    }
    IEnumerator close__tutorial()
    {
        yield return new WaitForSeconds(0.5f);
        tutorial.SetActive(false);
        flag__tut = 0;
        yield break;
    }
}
