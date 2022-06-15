using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSub : MonoBehaviour
{
    public GameObject animated__objected;
    public Vector3 verticle__increase;
    public Vector3 verticle__decrease;
    public Vector3 horizontal__increase;
    public Vector3 horizontal__decrease;
    public float speed = 0f;
    public float duration = 0f;
    public bool repeatable;
    // Start is called before the first frame update
    public IEnumerator Walk()
    {
        verticle__decrease = transform.localScale;
        horizontal__decrease = transform.localScale;
        while (repeatable)
        {
            yield return RepeatLerpVerticle(verticle__decrease, verticle__increase, duration);
            yield return RepeatLerpVerticle(verticle__increase, verticle__decrease, duration);
        }
            //yield return RepeatLerpHorizontal(horizontal__decrease, horizontal__increase, duration);
            //yield return RepeatLerpHorizontal(horizontal__increase, horizontal__decrease, duration);
    }
    public IEnumerator RepeatLerpVerticle(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i = i + Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
    public IEnumerator RepeatLerpHorizontal(Vector3 a, Vector3 b, float time)
    {
        float i = 0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i = i + Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
