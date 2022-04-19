using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;

public class BulletInstancier : MonoBehaviour
{
    public float spawnTimer;
    public BulletManager BulletSpawner1;

    void Awake()
    {
        //BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);

    }

    void Start()
    {
        
        StartCoroutine(BulletSpawn(spawnTimer));
        
    }

    void Update()
    {
       // BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);
    }

    IEnumerator BulletSpawn(float timer)
    {

        BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);

        yield return new WaitForSeconds(timer);

        StartCoroutine(BulletSpawn(timer));
    }

    public void Printer()
    {
        print(1);
    }
}
