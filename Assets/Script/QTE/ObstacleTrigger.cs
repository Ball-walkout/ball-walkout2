using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;
    Combo combo;
    int Combo_v;
    speedbar speedbar;
    private void Start() {
        combo = GameObject.Find("Combo").GetComponent<Combo>();
        speedbar = GameObject.Find("speedbarmove").transform.Find("timingopp").GetComponent<speedbar>();
    }

    private void Update() {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
            if(gameObject.CompareTag("slap")){
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        else{
            if(speedbar.cstop == false){
                if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                    gameObject.GetComponent<MeshCollider>().isTrigger = true;
                }
                if(gameObject.CompareTag("slap")){
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            else{
                if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                    gameObject.GetComponent<MeshCollider>().isTrigger = false;
                }
                if(gameObject.CompareTag("slap")){
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "ball"){
            if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true ||
             GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
                if(gameObject.name == "Tire (1)" || gameObject.name == "Tire (2)" || gameObject.name == "Tire (3)"){
                    return;
                }
                else if(gameObject.name == "Tire"){
                    gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                }
                else if(gameObject.CompareTag("car")){
                    int a = gameObject.transform.parent.GetSiblingIndex();
                    for(int i = 0; i < 5; i++){
                        if(i != a){
                            gameObject.transform.parent.GetChild(i).gameObject.SetActive(false);
                            return;
                        }
                    }
                }
                GameObject.Find("InGameUI").transform.Find("Combo").gameObject.SetActive(true);
                combo.Combo_v++;
                GameManager.Instance.SetCoin(1);
                Instantiate(QTEP, gameObject.transform.position + new Vector3(0, 5f, 0), Quaternion.Euler(90, 0, 0));
                gameObject.SetActive(false);
            }
        }
    }
}
