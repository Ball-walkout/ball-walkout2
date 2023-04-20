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
        DataManager.Instance.Resave(DataManager.Instance.stageNum, GameManager.Instance.star, GameManager.Instance.GetCoin());

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
        GameManager.Instance.ReleaseGame();
        string scene = (DataManager.Instance.stageNum + 1).ToString();
        print("1 - " + scene);
        SceneManager.LoadScene("1-" + scene);
        GameManager.Instance.time = 0;
        GameManager.Instance.timerOn = true;
    }

    public void ClickedNext()
    {
        GameManager.Instance.ReleaseGame();
        string scene = (DataManager.Instance.stageNum).ToString();
        print("1 - " + scene);
        SceneManager.LoadScene("1-" + scene);
        GameManager.Instance.time = 0;
        GameManager.Instance.timerOn = true;
    }

    private IEnumerator FillStar()
    {
        for (int i = 0; i < GameManager.Instance.star; i++)
        {
            stars[i].color = Color.yellow;
            fillOneStarBGM.Play();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
