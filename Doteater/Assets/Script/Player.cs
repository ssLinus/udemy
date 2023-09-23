using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    public static int score = 0;

    Player player;
    CharacterController charCtrl;
    Animator anim;
    TextMesh scoreOutput;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
        player = GameObject.Find(name:"Player").GetComponent<Player>();
        player.addScore(0);
    }

    void Update()
    {
        Scene nowScene = SceneManager.GetActiveScene();
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (dir.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude);
        if (GameObject.FindGameObjectsWithTag("Dot").Length < 1)
            switch (nowScene.name)
            {
                case "Main1":
                    SceneManager.LoadScene("Main2");
                    break;
                case "Main2":
                    SceneManager.LoadScene("Win");
                    break;
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                player.addScore(1);
                break;
            case "Enemy":
                SceneManager.LoadScene("Lose");
                break;
        }
    }
    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "Score : " + score;
    }
}