using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;
using BulletFury.Data;

public class BulletInstancier : MonoBehaviour
{
    public float spawnTimer;
    public BulletManager BulletSpawner1;
    [SerializeField, HideInInspector]public bool spawning;
    [SerializeField, HideInInspector]public bool disappear;
    Vector3 startLerp;
    Vector3 endLerp;
    public GameObject pSys;
    ParticleSystem instP;
    float t = 0;
    private void OnEnable()
    {
        spawning = true;
        StartCoroutine(BulletSpawn(spawnTimer));
        Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
        instP = Instantiate(pSys,transform.position,Quaternion.identity).GetComponent<ParticleSystem>();
        instP.transform.parent = transform;
    }


    IEnumerator BulletSpawn(float timer)
    {

        BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);

        yield return new WaitForSeconds(timer);

        if(spawning)
          StartCoroutine(BulletSpawn(timer));
        else if (!spawning)
        {
            if(GetComponent<MeshRenderer>() != null)
            {
                instP.Play();
                Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                foreach(MeshRenderer mesh in gameObject.GetComponentsInChildren<MeshRenderer>())
                {
                    mesh.enabled = false;
                    instP.Play();
                    Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
                }
            }
            //disappear = true;
/*          startLerp = transform.position;
            endLerp = transform.position - new Vector3(0, -20, 0);*/
        }
    }

    private void Update()
    {
        if (disappear)
        {
            //t += Time.deltaTime;
            
            //transform.position = Vector3.Lerp(startLerp, endLerp, t);
        }
    }
}
