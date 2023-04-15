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
        //Time.timeScale = 0f;
        GameManager.Instance.PauseGame();
    }

    public void ClickedMenu()
    {
        GameManager.Instance.time = 0;
        SceneManager.LoadScene("Start");
    }

    public void ClickedRestart()
    {
        string scene = (DataManager.Instance.stageNum + 1).ToString();
        print("1 - " + scene);
        SceneManager.LoadScene("1-" + scene);
        GameManager.Instance.time = 0;
        GameManager.Instance.timerOn = true;
    }

    public Text counter;
    public void ClickedContinue()
    {
        StartCoroutine(CountNumber());
    }

    private IEnumerator CountNumber()
    {
        int sec=3;
        while(sec > 0)
        {
            counter.text = sec.ToString();
            sec--;
            yield return new WaitForSeconds(1.0f);
            if(sec <= 0)
            {
                counter.text = "";
                GameManager.Instance.ReleaseGame();
                yield break;
            }
        }
    }

    [SerializeField] private RectTransform ballUI, enemyUI;
    Vector3 tempB, tempE;
    float preposB;
    float preposE;
    private void Start() {
        BGM.Play();
        GameManager.Instance.timerOn = true;
        preposB = GameObject.Find("ball").transform.position.z;
        preposE = GameObject.Find("Enemy").transform.position.z;
        ballUI = GameObject.Find("ballImg").GetComponent<RectTransform>();
        enemyUI = GameObject.Find("enemyImg").GetComponent<RectTransform>();
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
    private void UpdatePosition()
    {
        tempB = ballUI.transform.localPosition;
        tempB.y += (-GameObject.Find("ball").transform.position.z + preposB) * Time.deltaTime * 0.05f;
        ballUI.transform.localPosition = tempB;

        tempE = enemyUI.transform.localPosition;
        tempE.y += (-GameObject.Find("Enemy").transform.position.z + preposE) * Time.deltaTime * 0.05f;
        enemyUI.transform.localPosition = tempE;
    }
}