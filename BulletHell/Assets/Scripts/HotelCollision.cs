using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelCollision : MonoBehaviour
{
    Vector3 hotelTarget;
    Transform currentHotel;
    public float hotelFallSpeed;
    private void Update()
    {
        if(currentHotel != null)
            currentHotel.position = Vector3.Lerp(currentHotel.position, hotelTarget, Time.deltaTime * hotelFallSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            StartCoroutine(towerFallSound());
            FindObjectOfType<HotelManager>().hotelValue++;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Progress", FindObjectOfType<HotelManager>().hotelValue);
            FindObjectOfType<HotelManager>().TimeLineActivation();
            currentHotel = collision.transform;
            collision.collider.enabled = false;
            hotelTarget = currentHotel.position - new Vector3(0, 20, 0);
            collision.transform.parent.GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator towerFallSound()
    {
        Sound.sound.PlayOneShot("event:/TowerDestroy");
        yield return new WaitForSeconds(.8f);
        Sound.sound.PlayOneShot("event:/TowerDestroy Splash");
    }
}

