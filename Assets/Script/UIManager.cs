using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinTxt, scoreTxt;
    public void UpdateScore()
    {
        scoreTxt.text = GameManager.Instance.GetScore().ToString();
    }

    public void UpdateCoin()
    {
        coinTxt.text = GameManager.Instance.GetCoin().ToString();
    }

    [SerializeField] private GameObject overCanvas;
    public void GameOver()
    {
        overCanvas.SetActive(true);
        Invoke("StopScene", 0.5f);
    }

    [SerializeField] private GameObject optionsWindow;
    public void ClickedPause()
    {
        optionsWindow.SetActive(true);
        Invoke("StopScene", 0.5f);
    }

    private void StopScene()
    {
        Time.timeScale = 0f;
    }

    public void ClickedRestart()
    {
        GameManager.Instance.TurnOnTime();
        GameManager.Instance.time=0;
        GameManager.Instance.timerOn = true;
        SceneManager.LoadScene("Road");
    }

    public void ClickedContinue()
    {
        Time.timeScale = 1f;
    }

    private void Start() {
        
        GameManager.Instance.timerOn = true;
    }

    [SerializeField] private Text min, sec;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.timerOn)
        {
           min.text = GameManager.Instance.min.ToString();
           sec.text = GameManager.Instance.sec.ToString();
        }
    }
}
