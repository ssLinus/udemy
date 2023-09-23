using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float movespeed = 5f;
    public GameObject bullet;
    TextMesh scoreOutput;
    int score = 0;

    void Start()
    {
        scoreOutput = GameObject.Find(name: "Score") .GetComponent<TextMesh>();
    }


    void Update()
    {
        if (Input.GetButton("Up"))
        {
            transform.Translate(0, movespeed * Time.deltaTime, 0);
        }
        if (Input.GetButton("Down"))
        {
            transform.Translate(0, -movespeed * Time.deltaTime, 0);
        }
        if (Input.GetButton("Left"))
        {
            transform.Translate(-movespeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetButton("Right"))
        {
            transform.Translate(movespeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 pos = transform.position;
            Instantiate(bullet, pos, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "Á¡¼ö : " + score;
    }
}