using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{

  /*  private void OnCollisionEnter(Collision other) {
        Debug.Log(other.collider.gameObject.name);
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(other.collider.gameObject.CompareTag("slap")){
                other.collider.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else if(other.collider.gameObject.CompareTag("Obstacle") || other.collider.gameObject.CompareTag("purple")){
                Debug.Log(other.collider.gameObject.name);
                other.collider.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }*/

    private void OnTriggerStay(Collider other) {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(other.gameObject.CompareTag("slap")){
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else if(other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("purple")){
                Debug.Log(other.gameObject.name);
                other.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }
}
