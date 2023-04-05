using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;

    private void Start() {
        //gameObject.GetComponent<MeshCollider>().isTrigger = true; // .istrigger = true;
    }


    private void Update() {
        if(GameObject.Find("speedbarmove").transform.Find("tbeasy").GetComponent<speedbar>().onclick == true){
            gameObject.GetComponent<MeshCollider>().isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.name == "ball"){
            Debug.Log("?");
            QTEP.SetActive(true);
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
