using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public Slider progressionSlider;
    public MeshRenderer PlayerRenderer;
    /*[HideInInspector]*/ public int hpValue;
    public RectTransform[] Hearts = new RectTransform[3];
    public float SafeTimer;
    bool safe;
    public ParticleSystem deathPSys;
    
    private void Start()
    {
        hpValue = 3;
        safe = false;
    }


    private void Update()
    {
        //hpText.text = "" + hpValue;
        progressionSlider.value += Time.deltaTime / FindObjectOfType<BarriereMovement>().timer;
        if (hpValue <= 0)
        {
            StartCoroutine(Death());
        }
    }


    IEnumerator Death()
    {
        Destroy(FindObjectOfType<PlayerMovement>().transform.Find("Happy_Idle").gameObject);
        FindObjectOfType<PlayerMovement>().transform.Find("Death").GetComponent<ParticleSystem>().Play();
        
        yield return new WaitForSeconds(1.3f);
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void reduceHP(int hpLoss)
    {
        if (!safe)
        {
            Sound.sound.PlayOneShot("event:/Player/Damage");
            Hearts[hpValue - 1].gameObject.SetActive(false);
            hpValue -= hpLoss;
            StartCoroutine(InvicibilityFrames(SafeTimer));
        }
    }

    public void endLevel()
    {
        Sound.sound.PauseMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Sound.sound.PauseMusic.release();
        Sound.sound.Music.release();
        PlayerRenderer.gameObject.SetActive(false);
        GetComponent<Pause>().IsEndLevel();
    }

    IEnumerator InvicibilityFrames(float safeTimer)
    {
        safe = true;
        //PlayerRenderer.material.color = Color.blue;
        yield return new WaitForSeconds(safeTimer);
        //PlayerRenderer.material.color = Color.black;
        safe = false;
    }
}
    