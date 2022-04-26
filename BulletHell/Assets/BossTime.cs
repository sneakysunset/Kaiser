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
    public GameObject Boss;
    public GameObject wall1, wall2, wall3, wall4;
    public ParticleSystem pSys1, pSys2, pSys3, pSys4;

    public void Radeau()
    {
        pSys1.Stop();
        pSys2.Stop();
        pSys3.Stop();
        pSys4.Stop();

        wall1.SetActive(false);
        wall2.SetActive(false);
        wall3.SetActive(false);
        wall4.SetActive(false);
        Boss.SetActive(true)    ;
        radeauBool = true;
        jetPack.SetActive(true);
        bossTimeLine.enabled = true;
        radeau.GetComponent<BarriereMovement>().timer = 36;
        radeau.GetComponent<BarriereMovement>().StartTimer();
    }

    private void Update()
    {
        if(radeauBool)
            radeau.transform.Translate(0, Time.deltaTime * -radeauDownSpeed, 0);
    }

    
}
