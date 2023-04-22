using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;
    Combo combo;
    int Combo_v;
    private void Start() {
        combo = GameObject.Find("Combo").GetComponent<Combo>();
    }

    private void Update() {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            /*if(gameObject.CompareTag("slap")){
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else */if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple")){
              //  Debug.Log(gameObject.name);
                gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
            if(gameObject.CompareTag("car")){
              //  for(int i = 0; i < 5; i++){
                    gameObject.GetComponent<MeshCollider>().isTrigger = true;
              //  }
            }
        }
        else{
           /* if(gameObject.CompareTag("slap")){
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
            else*/ if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("purple")){
//                Debug.Log(gameObject.name);
                gameObject.GetComponent<MeshCollider>().isTrigger = false;
            }
            if(gameObject.CompareTag("car")){
               // for(int i = 0; i < 5; i++){
                    gameObject.GetComponent<MeshCollider>().isTrigger = false;
              //  }
            }
        }
       /* if(GameObject.Find("speedbarmove").transform.Find("").GetComponent<speedbar>().onclick == true){
            if(gameObject.CompareTag("slap")){
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else{
                gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
        }*/
    }

   /* private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.name == "ball"){
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }*/
    private void OnTriggerEnter(Collider other) {
        if(other.name == "ball"){
            if(gameObject.name == "Tire"){
                gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.parent.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.parent.GetChild(3).gameObject.SetActive(false); 
            }
            GameObject.Find("InGameUI").transform.Find("Combo").gameObject.SetActive(true);
            combo.Combo_v++;
            GameManager.Instance.SetCoin(1);
            Instantiate(QTEP, gameObject.transform.position + new Vector3(0, 5f, 0), Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }
   /* private void OnTriggerStay(Collider other) {
        if(other.gameObject.name == "ColliderCube" && GameObject.Find("speedbarmove").transform.Find("").GetComponent<speedbar>().onclick == true){// .gameObject.CompareTag("Star")){
            QTEP.SetActive(true);
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }*/
}
