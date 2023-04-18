using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] GameObject loading;
    [SerializeField] Text percentTxt;
    [SerializeField] Slider slider;
    private float time_loading = 2;
    private float time_current, time_start;
    private bool isLoad;

    public void LoadStart()
    {

        loading.SetActive(true);
        time_current = time_loading;
        time_start = Time.time;
        Set_FillAmount(0);
        isLoad = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isLoad)
        {
            time_current = Time.time - time_start;
            if (time_current < time_loading)
            {
                Set_FillAmount(time_current / time_loading);
            }
            else
            {
                Set_FillAmount(1);
            }
        }
    }

    string txt;
    private void Set_FillAmount(float _value)
    {
        slider.value = _value;
        txt = (_value.Equals(1) ? "Finished!" : "Loding ... ") + (_value).ToString("P");
        percentTxt.text = txt;
    }

    [SerializeField] Text cointxt;
    private void LoadCoin()
    {
        cointxt.text = DataManager.Instance.myUser.coins.ToString();
    }
    
    private void Start()
    {
        LoadCoin();
    }

    public void ClickedTutorial()
    {
        StartCoroutine(GIF());
    }
    public void ClickedClose()
    {
        canGIF = false;
    }

    [SerializeField] private Image tutor;
    [SerializeField] private Sprite [] tutorSprites;
    private bool canGIF = true;
    private IEnumerator GIF()
    {
        float fps = 0;
        while(canGIF)
        {
            tutor.sprite = tutorSprites[(int)(fps * 5)];
            fps += 0.2f;
            yield return new WaitForSeconds(0.2f);
            if(fps >= 2f)
                fps = 0;
        }
    }
}
