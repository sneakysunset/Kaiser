using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriereMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    Vector3 Direction;
    public float timer;
    ScoreManager scoreM;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        scoreM = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        transform.Rotate(0, 45, 0);
        Direction = transform.forward;
        transform.Rotate(0, -45, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * speed * Time.deltaTime;
    }

    IEnumerator endSceneTimer(float timeBeforeEnd)
    {
        yield return new WaitForSeconds(timeBeforeEnd);
        scoreM.endLevel();
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
