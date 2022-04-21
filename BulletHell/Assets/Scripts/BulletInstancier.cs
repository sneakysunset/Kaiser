using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletInstancier : MonoBehaviour
{
    public float spawnTimer;
    public BulletManager BulletSpawner1;


    private void OnEnable()
    {
        StartCoroutine(BulletSpawn(spawnTimer));
    }

    void Start()
    {
        
        StartCoroutine(BulletSpawn(spawnTimer));       
    }


    IEnumerator BulletSpawn(float timer)
    {

        BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);

        yield return new WaitForSeconds(timer);

        StartCoroutine(BulletSpawn(timer));
    }
}
