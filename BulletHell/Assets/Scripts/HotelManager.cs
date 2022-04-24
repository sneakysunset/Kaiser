using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HotelManager : MonoBehaviour
{
    public int hotelValue = 0;
    public GameObject[] TimeLines ;

    public void TimeLineActivation()
    {
        TimeLines[hotelValue-1].GetComponent<PlayableDirector>().enabled = true;
        Sound.sound.Music.setParameterByName("Progress", hotelValue);
    }
}
