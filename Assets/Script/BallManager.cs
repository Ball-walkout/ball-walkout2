using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public GameObject virCam, freeCam, goalEffect;
    public AudioSource coinBGM, obsBGM, boosterBGM, goalBGM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coinBGM.Play();
            GameManager.Instance.SetCoin(1);
            Destroy(other.gameObject, 0.1f);
        }
        else if(other.tag == "Obstacle")
        {
            obsBGM.Play();
            // 장애물 종류별 스코어 변경 필요 **
            GameManager.Instance.SetScore(10);
            //Destroy(other.gameObject, 30f);
        }
        else if(other.tag == "Booster")
        {
            boosterBGM.Play();
            freeCam.SetActive(true);
            virCam.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            obsBGM.Play();
        }

        else if(other.gameObject.tag == "Enemy")
        {
            GameManager.Instance.GameFail();
        }

        else if(other.gameObject.tag == "Goal")
        {
            transform.GetComponent<TouchMove>().Rallentare();
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            goalEffect.SetActive(true);
            goalBGM.Play();
            Invoke("GoalIn", 2f);
        }
    }

    private void GoalIn()
    {
        GameManager.Instance.timerOn = false;
        GameManager.Instance.StageClear();
        SceneManager.LoadScene("Clear");
    }

    public void SwitchCamera()
    {
        virCam.SetActive(true);
        freeCam.SetActive(false);
    }
}
