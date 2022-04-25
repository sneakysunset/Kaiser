using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        transform.Rotate(0, 180, 0);
    }
}
