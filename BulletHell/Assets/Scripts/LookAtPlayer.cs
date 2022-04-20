using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform playerPos;
    Vector3 targetPos;
    // Start is called before the first frame update
    private void Awake()
    {
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        
    }

    void Update()
    {
        targetPos = new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z);

        transform.LookAt(targetPos);
    }
}
