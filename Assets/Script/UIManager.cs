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
    public AudioSource gameOverBGM, BGM;
    public void GameOver()
    {
        BGM.Pause();
        gameOverBGM.Play();
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

    public void ClickedMenu()
    {
        GameManager.Instance.time = 0;
        SceneManager.LoadScene("Start");
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
        BGM.Play();
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
            UpdatePosition();
        }
    }

    [SerializeField] private RectTransform ballUI, enemyUI;
    private void UpdatePosition()
    {
        ballUI.position = new Vector3(ballUI.position.x, -400f + GameManager.Instance.ballPosZ * 9, ballUI.position.z);
        enemyUI.position = new Vector3(enemyUI.position.x, -400f + GameManager.Instance.enemyPosZ * 9, enemyUI.position.z);
    }
}
