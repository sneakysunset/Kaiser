using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletCollisionManager : MonoBehaviour
{
    ScoreManager scoreM;
    GameObject pSys;
    
    private void Awake()
    {
        scoreM = FindObjectOfType<ScoreManager>();    
    }

    public void OnPlayerHit(BulletContainer bulletContainer, BulletCollider bulletCollider)
    {
        scoreM.reduceHP(1);
        StartCoroutine(FindObjectOfType<ScreenShake>().Shake(.07f, .4f));
    }

    public void OnBulletHitPlayer(int i,bool hit,BulletContainer bulletContainer)
    {
        if (hit)
        {
            Instantiate(pSys, bulletContainer.Position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        }
    }
}
