using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelManager : MonoBehaviour
{
    [HideInInspector] public int hotelValue = 0;
    public GameObject[] TimeLines = new GameObject[4];
    public void HotelValueIncr()
    {
        hotelValue++;
    }

    public void TimeLineActivation()
    {
        TimeLines[hotelValue-1].SetActive(true);
    }
}
