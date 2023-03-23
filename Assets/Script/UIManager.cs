using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinTxt, scoreTxt;
    public void UpdateScore()
    {
        scoreTxt.text = GameManager.Instance.GetScore().ToString();
    }

    public void UpdateCoin()
    {
        coinTxt.text = GameManager.Instance.GetCoin().ToString();
    }

    public void GameOver()
    {
        
    }

    [SerializeField] private TMP_Text min, sec;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.timerOn)
        {
//            min.text = GameManager.Instance.min.ToString();
 //           sec.text = GameManager.Instance.sec.ToString();
        }
    }
}
