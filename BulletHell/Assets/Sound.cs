using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound sound { get; private set; }

    private void Awake()
    {
        if(sound == null)
        {
            sound = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void PlayOneShot(string eventName)
    {
        FMODUnity.RuntimeManager.PlayOneShot( eventName);
    }
}
