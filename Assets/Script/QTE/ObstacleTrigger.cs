using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;
    Combo combo;
    int Combo_v;
    BallTrigger ballTrigger;
    private void Start() {
        combo = GameObject.Find("Combo").GetComponent<Combo>();
        ballTrigger = GameObject.Find("TriggerCube").GetComponent<BallTrigger>();
    }

    private void Update() {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
        else{
            if(ballTrigger.cstop == false){
                if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                    gameObject.GetComponent<MeshCollider>().isTrigger = true;
                }
            }
            else{
                if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple") || gameObject.CompareTag("car")){
                    gameObject.GetComponent<MeshCollider>().isTrigger = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "ball"){
            if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true ||
             GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
                if(gameObject.name == "Tire"){
                    gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(3).gameObject.SetActive(false); 
                }
                if(gameObject.CompareTag("car")){
                    gameObject.transform.parent.GetChild(0).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
                    gameObject.transform.parent.GetChild(4).gameObject.SetActive(false);
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
