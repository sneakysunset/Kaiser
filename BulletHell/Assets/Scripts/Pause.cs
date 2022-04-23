using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool isPaused;
    bool isQuit;
    bool isEndLevel;
   
    public GameObject PauseMenu;
    public GameObject QuitMenu;
    public GameObject EndLevelMenu;

    private void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            PauseMenu.SetActive(false);
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


        Inputs();
    }


    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
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
        isEndLevel = true;
    }

    public void RestartLevelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Quit()
    {
        QuitMenu.SetActive(true);
        isQuit = true;
    }
    
    public void QuitQuit()
    {
        Application.Quit();
    }

    public void CancelQuit()
    {
        QuitMenu.SetActive(false);
        isQuit = false;
    }
}
