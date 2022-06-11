using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowWalk : MonoBehaviour
{
    public GameObject particle__system;
    public GameObject player;
    public bool is__shadow;
    MeshRenderer mesh;
    public Image ability__bar;
    public float fill__amount;

    // Start is called before the first frame update
    void Start()
    {
        mesh = player.GetComponent<MeshRenderer>();
        ability__bar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(execute__ability());
        }
        maintain__abilty();
        if (is__shadow)
        {
            ability__control__increase();
        }
        else
        {
            ability__control__decrease();
        }
    }
    void shadow__walker()
    {
        particle__system.SetActive(true);
        mesh.enabled = false;
        is__shadow = true;
    }
    void no__shadow()
    {
        particle__system.SetActive(false);
        mesh.enabled = true;
        is__shadow = false;
    }

    IEnumerator execute__ability()
    {
        if (!is__shadow)
        {
            shadow__walker();
        }
        else
        {
            no__shadow();
        }
        yield return new WaitForSeconds(1);
    }
    void ability__control__increase()
    {
        Debug.Log("Increase Abilty");
        ability__bar.fillAmount += (fill__amount / 100);
    }
    void ability__control__decrease()
    {
        Debug.Log("Decrease Abilty");
        ability__bar.fillAmount += -(fill__amount / 100);
    }
    void maintain__abilty()
    {
        if (ability__bar.fillAmount == 1)
        {
            no__shadow();
        }
    }
}
