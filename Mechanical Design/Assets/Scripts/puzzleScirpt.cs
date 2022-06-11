using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleScirpt : MonoBehaviour
{
    [Header("Game Objects For Puzzle")]
    public GameObject[] to__deactivate;
    public GameObject[] to__activate;
    public GameObject check__trigger;
    
    //referenced Scripts
    ArrayCheck myList;


   
    void Start()
    {
        myList = check__trigger.GetComponent<ArrayCheck>();
    }

   
    void Update()
    {
        
        if (myList.flag == 0)
        {
            activate__deactivate();
        }
    }
    
    void activate__deactivate()
    {
        for(int i=0; i<to__deactivate.Length; i++)
        {
            to__deactivate[i].SetActive(false);
        }
        for(int j=0; j<to__activate.Length; j++)
        {
            to__activate[j].SetActive(true);
        }
    }

}
