using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    [HideInInspector] public int hpValue;

    private void Start()
    {
        hpValue = 3;
    }


    private void Update()
    {
        hpText.text = "" + hpValue;

        if (hpValue <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void reduceHP(int hpLoss)
    {
        hpValue -= hpLoss;
    }

    public void endLevel()
    {
        GetComponent<Pause>().IsEndLevel();
    }
}
    