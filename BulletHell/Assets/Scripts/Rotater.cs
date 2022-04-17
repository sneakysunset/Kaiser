using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }
}
