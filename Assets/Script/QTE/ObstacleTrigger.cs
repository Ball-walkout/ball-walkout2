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
       /* if(GameObject.Find("speedbarmove").transform.Find("tbeasy").GetComponent<speedbar>().onclick == true){
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
            GameObject.Find("Canvas").transform.Find("Combo").gameObject.SetActive(true);
            combo.Combo_v++;
            Instantiate(QTEP, gameObject.transform.position + new Vector3(0, 5f, 0), Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }
   /* private void OnTriggerStay(Collider other) {
        if(other.gameObject.name == "ColliderCube" && GameObject.Find("speedbarmove").transform.Find("tbeasy").GetComponent<speedbar>().onclick == true){// .gameObject.CompareTag("Star")){
            QTEP.SetActive(true);
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }*/
}
