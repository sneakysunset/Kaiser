using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelCollision : MonoBehaviour
{
    Vector3 hotelTarget;
    Transform currentHotel;
    public float hotelFallSpeed;
    public HotelManager hotelM;

    private void Awake()
    {
        hotelM = FindObjectOfType<HotelManager>();
    }
    private void Update()
    {
        if(currentHotel != null)
            currentHotel.position = Vector3.Lerp(currentHotel.position, hotelTarget, Time.deltaTime * hotelFallSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            if(hotelM.hotelValue == 1)
            {
                hotelM.TimeLineDeActivation();
            }
            StartCoroutine(towerFallSound());
            hotelM.hotelValue++;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Progress", hotelM.hotelValue);
            hotelM.TimeLineActivation();
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

