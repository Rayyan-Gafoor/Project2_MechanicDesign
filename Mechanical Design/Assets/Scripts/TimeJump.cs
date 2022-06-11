using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJump : MonoBehaviour
{
    public int time_period_flag = 0;//0 = the present  1= the past
    public float teleportation_time = 1f;// time taken to teleport for the coroutin
    public float teleportation_timer = 2f;// time taken before you can teleport again
    public bool can_teleport = true;
    public float teleport_value;
    public Vector3 teleport_present;
    public Vector3 teleport_past;
    //PlayerController playerController;

    private void Start()
    {
       // playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
       
        teleport_present = new Vector3(gameObject.transform.position.x - teleport_value, gameObject.transform.position.y, gameObject.transform.position.z);
        teleport_past = new Vector3(gameObject.transform.position.x + teleport_value, gameObject.transform.position.y, gameObject.transform.position.z);
        if (Input.GetMouseButtonDown(1) && can_teleport==true)
        {
            StartCoroutine(can_Teleport());
            StartCoroutine(Teleportation());

        }
    }
    IEnumerator can_Teleport()
    {
        can_teleport = false;
        yield return new WaitForSeconds(teleportation_timer);
        can_teleport = true;
    }
    IEnumerator Teleportation()
    {
        
        if (time_period_flag == 0)
        {
            
            //playerController.disabled = true;
            yield return new WaitForSeconds(teleportation_time);
            //Debug.Log("TELEPORT TO THE PAST");
            gameObject.transform.position = teleport_past;
            time_period_flag = 1;
            yield return new WaitForSeconds(teleportation_time);
            //playerController.disabled = false;
            yield break;
        }
        else
        {
            
           // playerController.disabled = true;
            yield return new WaitForSeconds(teleportation_time);
            gameObject.transform.position = teleport_present;
            time_period_flag = 0;
            yield return new WaitForSeconds(teleportation_time);
           // playerController.disabled = false;
            yield break;
        }
        
    }

}
