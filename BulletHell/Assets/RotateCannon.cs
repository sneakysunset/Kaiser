using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public Transform Target;
    public float offTimer;
    public float onTimer;
    public bool lookAt;
    public float rotateSpeed;
    Quaternion look;

    void Update()
    {
        look = Quaternion.LookRotation(  transform.position -Target.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * rotateSpeed); 
        //transform.Rotate(0, 180, 0);

     
    }
}
