using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    public GameObject player;
    RespawnScript respawn;
    // Start is called before the first frame update
    void Start()
    {
        respawn = player.GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine(respawn.respawn__player());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
