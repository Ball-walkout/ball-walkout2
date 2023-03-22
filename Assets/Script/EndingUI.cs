using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;
    private void Start() {
        for(int i = 0; i<GameManager.Instance.star; i++)
        {
            stars[i].SetActive(true);
        }
    }
    public void ClickedReplay()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Road");
    }
}
