using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletCollisionManager : MonoBehaviour
{
    ScoreManager scoreM;

    private void Awake()
    {
        scoreM = FindObjectOfType<ScoreManager>();    
    }

    public void OnPlayerHit(BulletContainer bulletContainer, BulletCollider bulletCollider)
    {
        scoreM.reduceHP(1);
    }
}
