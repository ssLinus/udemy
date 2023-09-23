using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public int i;
    TextMesh scoreOutput;

    void Start()
    {
        i = Player.score;
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
        scoreOutput.text = "Score : " + i;
        
        Player.score = 0;
    }

    void Update()
    {

    }
}
