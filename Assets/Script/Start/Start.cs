using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Start : MonoBehaviour
{
    public void Stage(string stageNum){
        Invoke("LoadScene" + stageNum, 1.9f);
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

    private void LoadScene0()
    {
        SceneManager.LoadScene("1-1");
        DataManager.Instance.stageNum = 0;
    }
    private void LoadScene1()
    {
        SceneManager.LoadScene("1-2");
        DataManager.Instance.stageNum = 1;
    }
    private void LoadScene2()
    {
        SceneManager.LoadScene("1-3");
        DataManager.Instance.stageNum = 2;
    }
    private void LoadScene3()
    {
        SceneManager.LoadScene("1-4");
        DataManager.Instance.stageNum = 3;
    }
    private void LoadScene4()
    {
        SceneManager.LoadScene("1-5");
        DataManager.Instance.stageNum = 4;
    }
    private void LoadScene5()
    {
        SceneManager.LoadScene("1-6");
        DataManager.Instance.stageNum = 5;
    }
    private void LoadScene6()
    {
        SceneManager.LoadScene("1-7");
        DataManager.Instance.stageNum = 6;
    }
    private void LoadScene7()
    {
        SceneManager.LoadScene("1-8");
        DataManager.Instance.stageNum = 7;
    }
    private void LoadScene8()
    {
        SceneManager.LoadScene("1-9");
        DataManager.Instance.stageNum = 8;
    }
}
