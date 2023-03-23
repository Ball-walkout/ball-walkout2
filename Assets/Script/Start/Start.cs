using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Start : MonoBehaviour
{
    public void Stage(){
        SceneManager.LoadScene("Road");
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
}
