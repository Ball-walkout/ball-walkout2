using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Start : MonoBehaviour
{
    [SerializeField] GameObject loading;
    [SerializeField] Text percentTxt;
    [SerializeField] Slider slider;
    private bool isLoad=false;
    private float time_loading = 6;
    private float time_current, time_start;
    
    public void Stage(){
        loading.SetActive(true);
        time_current = time_loading;
        time_start = Time.time;
        Set_FillAmount(0);
        isLoad = true;
        Invoke("LoadScene", 1f);
        GameManager.Instance.TurnOnTime();
    }
    public void Level(){
        GameObject.Find("Canvas").transform.Find("LevelMenu").gameObject.SetActive(true);
        GameObject.Find("Setting").SetActive(false);
        GameObject.Find("Shop").SetActive(false);
        GameObject.Find("Start").SetActive(false);
    }

    public void Setting(){
        if(GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.activeSelf == true){
            GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(false);
        }
        else{
            GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(true);
        }
    }
    public void shop(){
        if(GameObject.Find("Canvas").transform.Find("ShopMenu").gameObject.activeSelf == true){
            GameObject.Find("Canvas").transform.Find("ShopMenu").gameObject.SetActive(false);
        }
        else{
            GameObject.Find("Canvas").transform.Find("ShopMenu").gameObject.SetActive(true);
        }
    }
    public void Back(){
        EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
    public void LevelBack(){
        GameObject.Find("LevelMenu").SetActive(false);
        GameObject.Find("Canvas").transform.Find("Setting").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Shop").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Start").gameObject.SetActive(true);
    }
    public void Coin()
    {
        if(GameObject.Find("GameManager"))
            GameObject.Find("Canvas").transform.Find("Coin").transform.Find("Text").GetComponent<Text>().text = GameManager.Instance.GetCoin().ToString();
    }

    string txt;
    private void Set_FillAmount(float _value)
    {
        slider.value = _value;
        txt = (_value.Equals(1) ? "Finished!" : "Loding ... ") + (_value).ToString("P");
        percentTxt.text = txt;
    }
    
    private void Update()
    {
        if(isLoad)
        {
            time_current = Time.time - time_start;
            if (time_current < time_loading)
            {
                print(time_current);
                Set_FillAmount(time_current / time_loading);
            }
            else
            {
                Set_FillAmount(1);
            }
        }
    }

    private void LoadScene()
    {

        SceneManager.LoadScene("Road");
    }
}
