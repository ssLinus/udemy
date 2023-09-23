using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    // ��� ������Ʈ�� ID ���
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        //��� ���� ������ ��� �������� �˻�
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
                animator.SetBool("Motion_Idle", true);
        else
                animator.SetBool("Motion_Idle", false);

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    Ugui.ShowMsgDisplay("�ȳ�!\n���õ� ������ �����غ���!!!");
                }
                else if (hitObj.tag =="Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    Ugui.ShowMsgDisplay("��!!");
                }
                else if (hitObj.tag =="Arm")
                {
                    System.DateTime now = System.DateTime.Now;
                    Ugui.ShowMsgDisplay("������ " + now.ToString() + "�̾�!!");
                }
            }
        }
    }
}