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
    Vector3 startLerp;
    Vector3 endLerp;
    public GameObject pSys;
    ParticleSystem instP;
    float t = 0;
    private void OnEnable()
    {
        spawning = true;
        StartCoroutine(BulletSpawn(spawnTimer));
        StartCoroutine(TrailActivation());
        Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
        instP = Instantiate(pSys,transform.position,Quaternion.identity).GetComponent<ParticleSystem>();
        instP.transform.parent = transform;
        instP.Play();
    }


    public void EndSpawn()
    {
        spawning = false;
        StartCoroutine(BulletSpawn(0));
    }

    IEnumerator TrailActivation()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Find("Trail").gameObject.SetActive(true);
    }

    IEnumerator BulletSpawn(float timer)
    {

        BulletSpawner1.Spawn(transform.position, forward: BulletSpawner1.Plane == BulletFury.Data.BulletPlane.XY ? transform.up : transform.forward);

        yield return new WaitForSeconds(timer);

        if(spawning)
          StartCoroutine(BulletSpawn(timer));
        else
        {
            if(GetComponent<MeshRenderer>() != null)
            {
                instP.Play();
                Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                transform.Find("Poulpe").gameObject.SetActive(false);
                instP.Play();
                Sound.sound.PlayOneShot("event:/Ennemy/Spawn");
             
            }
        }
    }

}
