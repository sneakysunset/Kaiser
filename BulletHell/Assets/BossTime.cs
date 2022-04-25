using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossTime : MonoBehaviour
{
    public PlayableDirector bossTimeLine;
    public GameObject jetPack;
    public Transform radeau;
    bool radeauBool;
    public float radeauDownSpeed;
    
    
    public void Radeau()
    {
        radeauBool = true;
        jetPack.SetActive(true);
        bossTimeLine.enabled = true;
        radeau.GetComponent<BarriereMovement>().timer = 30;
        radeau.GetComponent<BarriereMovement>().StartTimer();
    }

    private void Update()
    {
        if(radeauBool)
            radeau.transform.Translate(0, Time.deltaTime * -radeauDownSpeed, 0);
    }

    
}
