using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class ResetTimeLine : MonoBehaviour
{
    public PlayableDirector TimeLine2;
    public Animator[] Espadons = new Animator[5];
    public BulletBehaviorSupplement[] TimeLine0Items = new BulletBehaviorSupplement[8];
    public void resetTimeLine()
    {
        

        TimeLine2.time = 0;
        foreach(Animator espadon in Espadons)
        {
            espadon.SetTrigger("Reset");
        }
    }


    public void StopTimeLine()
    {
        foreach (BulletBehaviorSupplement star in TimeLine0Items)
        {
            star.enderSpawn();
            star.GetComponent<BulletInstancier>().EndSpawn();
        }
    }

    public void StopOtherTimeLine()
    {
        foreach(Animator anim in Espadons)
        {
            anim.gameObject.SetActive(false);
        }
        TimeLine2.enabled = false;
    }
}
