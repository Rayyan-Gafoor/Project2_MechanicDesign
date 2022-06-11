using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCheck : MonoBehaviour
{
    public List<GameObject> objects__in__array = new List<GameObject>();
    public List<GameObject> required__objects = new List<GameObject>();
    public int flag = 1;
    public int stop__flag = 0;

    private void Start()
    {
        flag = required__objects.Count;
    }
    private void FixedUpdate()
    {
        if (objects__in__array.Count >= required__objects.Count && stop__flag==0)
        {
            check__items();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "item")
        {
            objects__in__array.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            objects__in__array.Remove(other.gameObject);
        }
    }
    void check__items()
    {
        //Debug.Log("function is starting");
        for (int i = 0; i < objects__in__array.Count-1; i++)
        {
            //Debug.Log("function is in first phase");
            for (int j = 0; j < required__objects.Count -1; j++)
            {
                Debug.Log(required__objects[j].gameObject.name);
                Debug.Log(objects__in__array[j].gameObject.name);

                //Debug.Log("function is in second phase");
                if (required__objects[j].gameObject.name == objects__in__array[i].gameObject.name)
                {
                    StartCoroutine(flagset());
                    Debug.Log("checked");
                }
                else { continue; }
            }
        }
        
    }

    IEnumerator flagset()
    {
        flag--;
        yield return new WaitForSeconds(0.2f);
        if (flag == 0)
        {
            stop__flag = 1;
        }
        yield return new WaitForSeconds(0.2f);
        // yield return new WaitForSeconds(0.2f);
    }
}
