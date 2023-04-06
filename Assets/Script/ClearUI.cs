using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Text score, coin;
    public AudioSource fillOneStarBGM, AllStarBGM;
    private void Start() {
        // 별 한 개씩 채우기 효과
        for(int i = 0; i<GameManager.Instance.star; i++)
        {
            stars[i].color = Color.yellow;
            fillOneStarBGM.Play();
        }

        // 점수 및 코인 합산
        score.text = ((GameManager.Instance.GetScore() + GameManager.Instance.star) * 1000).ToString();
        coin.text = GameManager.Instance.GetCoin().ToString();
        DataManager.Instance.Resave(0, GameManager.Instance.star, GameManager.Instance.GetCoin());

        // 별 3개일 때 효과음
        if(GameManager.Instance.star==3)
            Invoke("PlayAllStar", 2f);
    }

    public void PlayAllStar()
    {
        AllStarBGM.Play();
    }

    public void ClickedMenu()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Start");
    }
    public void ClickedReplay()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Road");
        GameManager.Instance.TurnOnTime();
    }

    public void ClickedNext()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Start");
    }
}
