using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadon : MonoBehaviour
{
    
    public void ChargeRay()
    {
        Sound.sound.PlayOneShot("event:/Ennemy/Espadon/Charge");
    }

    public void ShootRay()
    {
        Sound.sound.PlayOneShot("event:/Ennemy/Espadon/Tir");
    }
}
