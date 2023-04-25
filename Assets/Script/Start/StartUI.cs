using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    // LOADING
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

    // Coin
    [SerializeField] Text cointxt;
    private void LoadCoin()
    {
        cointxt.text = DataManager.Instance.myUser.coins.ToString();
    }
    
    private void Start()
    {
        LoadCoin();
        LoadPurchase();
        LoadStars();
    }

    [SerializeField] GameObject[] stageStars;
    // Load Stars of each Stage
    private void LoadStars()
    {
        for (int i = 0; i<9; i++)
        {
            for(int j=0;j<DataManager.Instance.myUser.levelCleared[i];j++)
            {
                stageStars[i].GetComponentsInChildren<Image>()[j].gameObject.SetActive(true);
            }
        }
    }

    // Tutorial Window On/Off

    public void ClickedTutorial()
    {
        StartCoroutine(GIF());
    }
    public void ClickedClose()
    {
        canGIF = false;
    }

    // Tutorial GIF Image animation
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

    private int[] skinPrice = {100, 100, 100, 100, 100,
                            200, 200, 200, 200, 200, 200, 200,
                            300, 300};
    [SerializeField]private GameObject[] purchaseBtns, selectBtns, selectedBtns;
    public void Purchase(int select)
    {
        if (DataManager.Instance.myUser.coins >= skinPrice[select])
        {
            // Update coin
            DataManager.Instance.myUser.coins -= skinPrice[select];
            DataManager.Instance.UpdatePurchase(select);
            LoadCoin();
            // update button
            purchaseBtns[select].SetActive(false);
            selectBtns[select].SetActive(true);
        }
    }

    private void LoadPurchase()
    {
        for (int i = 0; i<14; i++)
        {
            if(DataManager.Instance.myUser.skin_purchased[i]==true)
            {
                // update button
                purchaseBtns[i].SetActive(false);
                selectBtns[i].SetActive(true);
                if(i == DataManager.Instance.myUser.ball_skin)
                {
                    // 선택한 스킨 버튼 업데이트
                    selectBtns[i].SetActive(false);
                    selectedBtns[i].SetActive(true);
                }
            }
        }
    }
    public void SelectSkin(int select)
    {
        if(selectBtns[select].activeSelf==true && selectedBtns[select].activeSelf==false)
        {
            // 기존 스킨 버튼 업데이트
            selectBtns[DataManager.Instance.myUser.ball_skin].SetActive(true);
            selectedBtns[DataManager.Instance.myUser.ball_skin].SetActive(false);
            // 선택한 스킨 버튼 업데이트
            selectBtns[select].SetActive(false);
            selectedBtns[select].SetActive(true);
            DataManager.Instance.UpdateBall(select);
        }
    }
}
