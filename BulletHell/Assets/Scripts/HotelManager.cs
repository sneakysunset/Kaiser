using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HotelManager : MonoBehaviour
{
    public int hotelValue = 0;
    public GameObject[] TimeLines ;

    private void Start()
    {
        Sound.sound.Music.setParameterByName("Progress", 0);
    }

    public void TimeLineActivation()
    {
        TimeLines[hotelValue-1].GetComponent<PlayableDirector>().enabled = true;
        
    }
}
