using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Rigidbody radeauRb;
    public float moveSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = /*radeauRb.velocity +*/ (new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            FindObjectOfType<ScoreManager>().reduceHP(1);
        }
    }

   
}
