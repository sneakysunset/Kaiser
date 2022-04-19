using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriereMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    Vector3 Direction;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.Rotate(0, 45, 0);
        Direction = transform.forward;
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barriere")
        {
            Direction = Vector3.Reflect(Direction, collision.GetContact(0).normal);
            
            //Direction = transform.forward;
        }
    }
}
