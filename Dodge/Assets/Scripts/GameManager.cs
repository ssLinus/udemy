using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public GameObject[] life;

    private float surviveTime;

    public static bool isGameover;


    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }


    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void LifeCheck()
    {
        life[PlayerController.hitCount].gameObject.SetActive(false);
    }

    public void EndGame()
    {
        isGameover = true;

        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }
}