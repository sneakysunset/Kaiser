using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public void WalkSound()
    {
        Sound.sound.PlayOneShot("event:/Player/Step");
    }
}
