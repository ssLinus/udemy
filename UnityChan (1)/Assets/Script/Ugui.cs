using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ugui : MonoBehaviour
{
    public Janken janken;

    public Button[] buttons;
    const int JankenBtn = 0;
    const int GooBtn = 1;
    const int ChokiBtn = 2;
    const int ParBtn = 3;

    public static string str;
    public static bool flagDisplay = false;

    public GameObject msgDisp;

    void Start()
    {
        janken = GameObject.Find("unitychan").GetComponent<Janken>();
        msgDisp.SetActive(false);
    }

    public void SettigJanken()
    {
        janken.flagJanken = true;
        buttons[JankenBtn].gameObject.SetActive(false);
        StartJanken();
    }

    void StartJanken()
    {
        buttons[GooBtn].gameObject.SetActive(true);
        buttons[ChokiBtn].gameObject.SetActive(true);
        buttons[ParBtn].gameObject.SetActive(true);
    }

    void EndJanken()
    {
        buttons[GooBtn].gameObject.SetActive(false);
        buttons[ChokiBtn].gameObject.SetActive(false);
        buttons[ParBtn].gameObject.SetActive(false);
        buttons[JankenBtn].gameObject.SetActive(true);
    }

    public void OnClickGoo()
    {
        janken.modeJanken += 1;
        janken.myHand = janken.GetGOO();
        EndJanken();
    }

    public void OnClickChoki()
    {
        janken.modeJanken += 1;
        janken.myHand = janken.GetCHOKI();
        EndJanken();
    }

    public void OnClickPar()
    {
        janken.modeJanken += 1;
        janken.myHand = janken.GetPAR();
        EndJanken();
    }

    public static void ShowMsgDisplay(string str)
    {
        Ugui.str = str;
        flagDisplay = true;
    }

    private void Update()
    {
        if(flagDisplay)
        {
            ShowUi();
            flagDisplay = false;
        }
    }

    private void ShowUi()
    {
        if (flagDisplay)
        {
            msgDisp.SetActive(true);

            Text TimeTxt = msgDisp.GetComponentInChildren<Text>();
            StartCoroutine(Typing(TimeTxt, str, 1));
        }
    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i <= message.Length; i++)
        {
            typingText.text = message.Substring(0, i);
            yield return new WaitForSeconds(speed * 0.05f);
        }
        yield return new WaitForSeconds(speed * 2f);
        msgDisp.SetActive(false);
    }
}