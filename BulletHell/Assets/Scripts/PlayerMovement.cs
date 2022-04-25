using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Rigidbody radeauRb;
    public float moveSpeed;
    Vector2 normals;
    bool playMoveSound = true;
    public GameObject jetPack;
    public Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    IEnumerator playPonctualSound(string name, float timer)
    {
        playMoveSound = false;
        yield return new WaitForSeconds(timer);
        playMoveSound = true;
        Sound.sound.PlayOneShot(name);
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            transform.rotation = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        bool message;
        message = rb.velocity.magnitude > 0 ? true : false;
        anim.SetBool("Run", message);



        if(anim.GetBool("Run") && !anim.GetBool("Cow") && playMoveSound && (!jetPack.activeSelf || jetPack == null))
        {
            
            StartCoroutine(playPonctualSound("event:/Player/Step", .2f));
        }

        if (anim.GetBool("Cow") && playMoveSound && (!jetPack.activeSelf || jetPack == null))
        {
            StartCoroutine(playPonctualSound("event:/Player/Rame", .2f));
        }

        if(jetPack != null)
        {
            if (jetPack.activeSelf && playMoveSound)
            {
               Sound.sound.PlayOneShot("event:/Player/JetPack");
                playMoveSound = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(radeauRb != null)
        {
            rb.velocity = radeauRb.velocity + (new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));       
        }
        else{
            rb.velocity = (new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
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
