using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Sound : MonoBehaviour
{
    public static Sound sound { get; private set; }
    FMOD.Studio.EventInstance MainMusic1;
    FMOD.Studio.EventInstance MainMusic2;
    FMOD.Studio.EventInstance MainMusic3;
    FMOD.Studio.EventInstance MainMenuMusic;
    FMOD.Studio.EventInstance Pause1;
    FMOD.Studio.EventInstance Pause2;
    FMOD.Studio.EventInstance Pause3;
    public FMOD.Studio.EventInstance Music;
    public FMOD.Studio.EventInstance PauseMusic;


    private void Awake()
    {
        MainMusic1 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST1");
        MainMusic2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST2");
        MainMusic3 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST3");
        MainMenuMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST3");
        Pause1 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST1_Pause");
        Pause2 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST2_Pause");
        Pause3 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/OST3_Pause");

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Music = MainMusic1;
            PauseMusic = Pause1;
        }
        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            Music = MainMusic2;
            PauseMusic = Pause2;
        }
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            Music = MainMusic3;
            PauseMusic = Pause3;
        }        
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Music = MainMenuMusic;
            PauseMusic = Pause3;
        }


        Music.start();
        PauseMusic.start();


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
