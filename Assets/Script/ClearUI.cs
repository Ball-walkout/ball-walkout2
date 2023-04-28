using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Text score, coin, stageNum;
    public AudioSource fillOneStarBGM, AllStarBGM;
    private void Start() {
        stageNum.text = (DataManager.Instance.stageNum+1).ToString();

        // 별 한 개씩 채우기 효과
        StartCoroutine(FillStar());

        // 점수 및 코인 합산
        score.text = ((GameManager.Instance.GetScore() + GameManager.Instance.star) * 1000).ToString();
        coin.text = GameManager.Instance.GetCoin().ToString();

        // 스테이지 클리어 별 개수
        int finalStar=0, dataStar=0;
        dataStar = DataManager.Instance.myUser.levelCleared[DataManager.Instance.stageNum];
        // 스테이지 첫 클리어 시 별 개수 새로 update
        if(dataStar == 0)
            finalStar = GameManager.Instance.star;
        // 이미 스테이지 클리어한 기록이 있을 때, 더 큰 별 개수로 update
        else
            finalStar = GameManager.Instance.star > dataStar ? GameManager.Instance.star : dataStar;
        DataManager.Instance.Resave(DataManager.Instance.stageNum, finalStar, GameManager.Instance.GetCoin());

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
        string scene = (DataManager.Instance.stageNum + 1).ToString();
        print("1 - " + scene);
        SceneManager.LoadScene("1-" + scene);
        GameManager.Instance.time = 0;
        GameManager.Instance.timerOn = true;
    }

    public void ClickedNext()
    {
        
        string scene = (DataManager.Instance.stageNum + 2).ToString();
        print("1 - " + scene);
        SceneManager.LoadScene("1-" + scene);
        GameManager.Instance.time = 0;
        GameManager.Instance.timerOn = true;
    }

    [SerializeField] private Sprite yellowStar;
    [SerializeField] private GameObject[] starEffect;
    private IEnumerator FillStar()
    {
        for (int i = 0; i < GameManager.Instance.star; i++)
        {
            stars[i].sprite = yellowStar;
            starEffect[i].SetActive(true);
            fillOneStarBGM.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
