using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject checkpoint;
    public GameObject Player;
    public bool is__dead= false;
    public int life__count = 3;
    TimeJump time__jump;

    // Start is called before the first frame update
    void Start()
    {
        time__jump = Player.GetComponent<TimeJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is__dead)
        {
            //Debug.Log("player respawn");
            
            StartCoroutine(respawn__player());
            
        }
    }
    public IEnumerator respawn__player()
    {
        time__jump.time_period_flag = 0;
        Debug.Log("respawn");
        transform.position = checkpoint.transform.position;
        
        is__dead = false;
        
        //life__count = life__count - 1;
        
        
        yield break;
    }

}

