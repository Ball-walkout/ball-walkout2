using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailUI : MonoBehaviour
{
    public void ClickedReplay()
    {
        GameManager.Instance.time=0;
        SceneManager.LoadScene("Road");
    }

    public void ClickedNext()
    {
        Time.timeScale=1;
    }
}
