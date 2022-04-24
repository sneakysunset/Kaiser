using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Rigidbody radeauRb;
    public float moveSpeed;
    Vector2 normals;

    public Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            transform.rotation = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        bool message;
        message = rb.velocity.magnitude > 0 ? true : false;
        anim.SetBool("Run", message);
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

    private void OnCollisionStay(Collision collision)
    {
        normals = new Vector2(collision.GetContact(0).normal.x, collision.GetContact(0).normal.z);
        bool message;
        message = rb.velocity.magnitude > 0 ? true : false;
        anim.SetBool("Cow", message);
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("Cow", false);
    }

}
