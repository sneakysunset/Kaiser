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
        GetComponent<Pause>().IsEndLevel();
    }

    IEnumerator InvicibilityFrames(float safeTimer)
    {
        safe = true;
        PlayerRenderer.material.color = Color.blue;
        yield return new WaitForSeconds(safeTimer);
        PlayerRenderer.material.color = Color.black;
        safe = false;
    }
}
    