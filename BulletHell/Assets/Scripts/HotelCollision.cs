using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.layer == 9)
        {
            FindObjectOfType<HotelManager>().hotelValue++;
            FindObjectOfType<HotelManager>().TimeLineActivation();

            Destroy(collision.transform.gameObject);
        }
    }
}

