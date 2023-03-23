using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    private void Start() {
        for(int i = 0; i<GameManager.Instance.star; i++)
        {
            stars[i].color = Color.yellow;
        }
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
    }

    public void ClickedNext()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Stage");
    }
}
