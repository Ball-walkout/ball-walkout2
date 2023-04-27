using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] Continueimage = new GameObject[3];
    private void Start() {
        BGM.Play();
        GameManager.Instance.timerOn = true;
        Continueimage[0] = gameObject.transform.GetChild(0).gameObject;
        Continueimage[1] = gameObject.transform.GetChild(1).gameObject;
        Continueimage[2] = gameObject.transform.GetChild(2).gameObject;
    }
    [SerializeField] private Text scoreTxt;
    public void UpdateScore()
    {
        scoreTxt.text = GameManager.Instance.GetScore().ToString();
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
        GameManager.Instance.ReleaseGame();
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
            Continueimage[sec-1].SetActive(true);
            if(sec != 3){
                Continueimage[sec].SetActive(false);
            }
            sec--;
            yield return new WaitForSeconds(1.0f);
            if(sec <= 0)
            {
                Continueimage[sec].SetActive(false);
                GameManager.Instance.ReleaseGame();
                yield break;
            }
        }
    }

    [SerializeField] private RectTransform ballUI, enemyUI;
    Vector3 tempB, tempE;

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