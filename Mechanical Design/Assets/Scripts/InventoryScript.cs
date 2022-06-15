using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject hand;
    public GameObject pickup__UI;
    public float shrink__size;
    public bool hand__full = false;
    Rigidbody rb;
    public bool can__pick;
    public Transform player;
    public float reach__distance;
    public LayerMask item__mask;
    //[SerializeField] GameObject temp__item;

    // Start is called before the first frame update
    void Start()
    {
        pickup__UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // can__pick = Physics.CheckSphere(player.position, reach__distance, item__mask);
        if (Input.GetKeyDown(KeyCode.Q) && hand__full == true)
        {
            drop__item();
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item")
        {
            if (hand__full)
            {
                pickup__UI.SetActive(false);
            }
            else { pickup__UI.SetActive(true); }
            if (Input.GetKeyDown(KeyCode.E) && hand__full==false)
            {
                pickup__item(other.gameObject);
                //Debug.Log("Can Pick Up");
            }
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            pickup__UI.SetActive(false);
        }
    }
    void pickup__item(GameObject item)
    {
        rb = item.gameObject.GetComponent<Rigidbody>();
        item.transform.position = hand.transform.position;
        item.transform.parent = hand.transform;
        hand__full = true;
        rb.useGravity = false;
        rb.drag = 10;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        
        item.GetComponent<Collider>().enabled = false;
        //Debug.Log("item in Hand");
        //Debug.Log(hand.get)
    }
    void drop__item()
    {
        GameObject child = hand.transform.GetChild(0).gameObject;
        rb = child.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.drag = 0;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.None;
        child.GetComponent<Collider>().enabled = true;
        child.transform.parent = null;
        hand__full = false;
       // Debug.Log("item Dropped");

    }
}
