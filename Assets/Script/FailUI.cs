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
        GameManager.Instance.TurnOnTime();
    }

    public void ClickedNext()
    {
        GameManager.Instance.TurnOnTime();
    }
}
