using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Start : MonoBehaviour
{
    public void Stage(string stageNum){
        DataManager.Instance.stageNum = int.Parse(stageNum);
        print("StageNum: "+DataManager.Instance.stageNum.ToString());
        Invoke("LoadScene", 1.9f);
    }

    public void Level(){
        GameObject.Find("Canvas").transform.Find("LevelMenu").gameObject.SetActive(true);
        GameObject.Find("Setting").SetActive(false);
        GameObject.Find("Shop").SetActive(false);
        GameObject.Find("Start").SetActive(false);
    }

    [SerializeField]private Image soundImg;
    [SerializeField]private Sprite soundOn, soundOff;
    [SerializeField] private Text soundText;
    public void Sound(){
        if(AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            soundImg.sprite = soundOff;
            soundText.text = "SOUND ON";
        }
        else
        {
            AudioListener.volume = 1;
            soundImg.sprite = soundOn;
            soundText.text = "SOUND OFF";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
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

    private void LoadScene()
    {
        SceneManager.LoadScene("1-"+(DataManager.Instance.stageNum+1).ToString());
    }
}
