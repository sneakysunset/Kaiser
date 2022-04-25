using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool isPaused;
    bool isQuit;
    bool isEndLevel;

    public Slider volumeSlider;
    public GameObject PauseMenu;
    public GameObject QuitMenu;
    public GameObject EndLevelMenu;
    public Animator player;
    private void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            if(!PauseMenu.activeSelf)
            Sound.sound.PlayOneShot("event:/UI/SFX Button");
            Sound.sound.Music.setPaused(true);
            
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Paused", 1);
            PauseMenu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
            Sound.sound.Music.setPaused(false);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Paused", 0);
            Time.timeScale = 1;
        }

        if (isEndLevel)
        {
            Time.timeScale = 0;
            EndLevelMenu.SetActive(true);
        }
        else if(!isEndLevel && !isPaused)
        {
            EndLevelMenu.SetActive(false);
            Time.timeScale = 1;
        }

        VolumeSlider();

        Inputs();
    }
    

    void VolumeSlider()
    {

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Volume", volumeSlider.value);
    }


    public void startLevel1()
    {
        StartCoroutine(StartLevel1());
    }

    public void startLevel2()
    {
        StartCoroutine(StartLevel2());
    }

    public void startLevel3()
    {
        StartCoroutine(StartLevel3());
    }

    IEnumerator StartLevel1()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
        player.SetTrigger("Celebrate");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Level 1");
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
    }




    IEnumerator StartLevel2()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
        player.SetTrigger("Celebrate");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Level 2");
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
    }
    IEnumerator StartLevel3()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
        player.SetTrigger("Celebrate");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Level 3");
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
    }

    void Inputs()
    {
        if (Input.GetButtonDown("Cancel") && !isEndLevel)
        {           
            if (isPaused)
                Resume();
            else if (!isPaused)
                isPaused = true;
        }
        
    }

    public void IsEndLevel()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
        isEndLevel = true;
    }

    public void RestartLevelClick()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
    }

    public void NextLevel()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
    }

    public void MainMenu()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button back");
        SceneManager.LoadScene("MainMenu");
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
    }

    public void Resume()
    {
        isPaused = false;
        Sound.sound.PlayOneShot("event:/UI/SFX Button back");
    }

    public void Quit()
    {
        QuitMenu.SetActive(true);
        isQuit = true;
        Sound.sound.PlayOneShot("event:/UI/SFX Button back");
    }
    
    public void QuitQuit()
    {
        Sound.sound.PlayOneShot("event:/UI/SFX Button back");
        Application.Quit();
    }

    public void CancelQuit()
    {
        QuitMenu.SetActive(false);
        isQuit = false;
        Sound.sound.PlayOneShot("event:/UI/SFX Button");
    }
}
