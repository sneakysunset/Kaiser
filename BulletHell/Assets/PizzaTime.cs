using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTime : MonoBehaviour
{
    Vector3 ogPos;
    Vector3 targetPos;
    bool moving = true;
    float interpolationValue;
    public float speed;
    public float timeToPlayPSys;
    bool pSysNotYetPlayed = true;
    public ParticleSystem pSys;
    void Start()
    {
        ogPos = transform.position;
        targetPos = ogPos + new Vector3(0, -ogPos.y, 0);
    }


    void Update()
    {
        if (moving)
        {
            interpolationValue += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(ogPos, targetPos, interpolationValue);
        }

        if(interpolationValue >= timeToPlayPSys && pSysNotYetPlayed)
        {
            pSysNotYetPlayed = false;
            pSys.Play();
        }

        if(interpolationValue >= 1)
        {
            moving = false;
            transform.position = targetPos;
        }
    }
}
