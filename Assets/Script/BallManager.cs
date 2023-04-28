using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using PathCreation.Examples;

public class BallManager : MonoBehaviour
{
    public GameObject virCam, freeCam, goalEffect;
    public AudioSource coinBGM, obsBGM, boosterBGM, goalBGM;
    speedbar speedbar;

    private void Start() {
        speedbar = GameObject.Find("speedbarmove").transform.Find("timingopp").GetComponent<speedbar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coinBGM.Play();
            GameManager.Instance.SetCoin(1);
            Destroy(other.gameObject, 0.1f);
        }
        else if(other.tag == "Obstacle" || other.tag == "slap" || other.tag == "car" || other.tag == "purple")
        {
            if(speedbar.cstop == true || GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
            GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
                obsBGM.Play();
            }
        }
        else if(other.tag == "Booster")
        {
            if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == false && 
            GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == false){
                boosterBGM.Play();
            }
        }
        
    }

    TouchMove tm;
    PathFollower PF;
    bool isStopped = false;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "slap" || other.gameObject.tag == "car")
        {
            // 공 가속 멈추고, 기준 축도 멈추기
            if(!GameManager.Instance.isQTE)
            {
                tm = transform.GetComponent<TouchMove>();
                tm.Rallentare();
                PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
                if (!isStopped)
                {
                    PF.speed = 0;
                    isStopped = true;
                    Invoke("RestartPF", 0.1f);
                }
                else
                    Invoke("RestartPF", 0.1f);
            }
            
            obsBGM.Play();
        }

        else if(other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.GameFail();
        }

        else if(other.gameObject.tag == "Goal")
        {
            GameManager.Instance.PauseGame();
            goalEffect.SetActive(true);
            goalBGM.Play();
            Invoke("GoalIn", 2f);
        }
    }

    private void GoalIn()
    {
        GameManager.Instance.StageClear();
        SceneManager.LoadScene("Clear");
    }

    private void RestartPF()
    {
        PF.speed = 20f;
        isStopped =false;
        tm.Accelerate();
        tm.EnTouch();
    }

    
}
