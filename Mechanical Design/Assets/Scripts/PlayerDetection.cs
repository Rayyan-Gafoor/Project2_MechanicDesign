using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetection : MonoBehaviour
{
    //Enemy Type Determines their behaviour
    public enum enemy__type {Scout, Runner}
    public enemy__type EnemyType;
 
    //Enemy Scout Ai parameters
    public GameObject player;
    public Transform target;
    [SerializeField] float angle;
    [SerializeField] float p_vision = 90;
    [SerializeField] float playerRange;

    //Enemy Scout Type Rotation parameters
    [Header("Scout Type Parameters")]
    [SerializeField] float x__rotation;
    [SerializeField] float y__rotation;
    [SerializeField] float z__rotation;

    //Detection Ui
    public Image DetectionBar;
    public float FillAmount;

    //Scripts to reference
    //respawn script to trigger players death
    RespawnScript respawn;
    ShadowWalk shadow__walk;

    private void Start()
    {
       
       // target = GameObject.Find("target").transform;
        respawn = player.GetComponent<RespawnScript>();
        shadow__walk = player.GetComponent<ShadowWalk>();

    }
    private void Update()
    {
        player__infront();
        player__insight();
        player__inrange();
        kill__player();
        bar__colour__control();
        if (player__infront() && player__insight() && player__inrange() && !shadow__walk.is__shadow)
        {
            detection__control__increase();
            //Increase Detection Meter.
            Debug.Log("Oh No The Enemy Is Onto You");
        }
        else
        {
            detection__control__decrease();
        }
        //enemy Scout
        rotate__search();
    }
    #region Enemy Detection Functions
    bool player__infront()
    {
        Vector3 player__dir = transform.position - player.transform.position;
        angle = Vector3.Angle(transform.forward, player__dir);
        if(Mathf.Abs(angle) > p_vision && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            return true;
        }
        return false;
    }
    bool player__insight()
    {
        /*RaycastHit hit;
        Vector3 player__dir = player.position - transform.position;
        if(Physics.Raycast(transform.position, player__dir, out hit, 50000f))
        {
            if(hit.transform.name == "ValveMC")
            {
                Debug.DrawLine(transform.position, player.position, Color.yellow);
                return true;
            }
        }*/
        RaycastHit hit;
        Vector3 player__dir = target.position - transform.position;
       
        if (Physics.Raycast(transform.position, player__dir, out hit, 50000f))
        {
            
            if (hit.collider.transform == target)
            {
                //Debug.DrawLine(transform.position, target.position, Color.green);
                Debug.DrawLine(transform.position, target.position, Color.yellow);
                return true;
            }
        }
        return false;
    }
    bool player__inrange()
    {
        float current__dis;
        current__dis = Vector3.Distance(transform.position, player.transform.position);
        if(current__dis< playerRange)
        {
            return true;
        }
        return false;
    }
    void bar__colour__control()
    {
        if (DetectionBar.fillAmount<0.5)
        {
            DetectionBar.color = Color.green;
        }
        else if (DetectionBar.fillAmount > 0.5)
        {
            DetectionBar.color = Color.yellow;
        }
        else if (DetectionBar.fillAmount > 0.8)
        {
            DetectionBar.color = Color.red;
        }
    }
    void detection__control__increase()
    {
        //Debug.Log("Increase");
        DetectionBar.fillAmount += (FillAmount / 100);
    }
    void detection__control__decrease()
    {
       // Debug.Log("Decrease");
        DetectionBar.fillAmount += -(FillAmount / 100);
    }
    void kill__player()
    {
        if (DetectionBar.fillAmount == 1)
        {
            respawn.is__dead = true;
        }
    }
    #endregion
    #region Enemy Scout Functions
    void rotate__search()
    {
        if (is__searching())//looks if enemy detects the player
        {
            //do nothing 
        }
        else
        {
            transform.Rotate(x__rotation * Time.deltaTime, y__rotation * Time.deltaTime, z__rotation * Time.deltaTime);
        }
    }
    bool is__searching()
    {
        if (player__infront() && player__insight() && player__inrange() && !shadow__walk.is__shadow)
        {
            return true;// return true if the enemy has detected the player.
        }
        return false;
    }
    #endregion

}
