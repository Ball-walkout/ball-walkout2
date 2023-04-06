using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;
    public bool triggerB;
    private void Start() {
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

    /*private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.name == "ball"){
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }*/
    private void OnTriggerEnter(Collider other) {
        if(other.name == "ball"){
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
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
