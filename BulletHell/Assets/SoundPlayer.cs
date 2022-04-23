using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury.Data;

public class SoundPlayer : MonoBehaviour
{
    
   

    public void PlayOneShotStar(int i, BulletContainer bC)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ennemy/Etoile/Tir");
    }

    public void PlayOneShotPoulpe(int i, BulletContainer bC)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ennemy/Poulpe/Tir");
    }

    public void PlayOneShotRaie(int i, BulletContainer bC)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ennemy/Raie/Tir");
    }

    public void PlayOneShotBomb(int i, BulletContainer bC)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ennemy/Bombe/Tir");
    }
}
