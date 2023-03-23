using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Text score, coin;
    private void Start() {
        for(int i = 0; i<GameManager.Instance.star; i++)
        {
            stars[i].color = Color.yellow;
        }
        score.text = ((GameManager.Instance.GetScore() + GameManager.Instance.star) * 1000).ToString();
        coin.text = GameManager.Instance.GetCoin().ToString();
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
