using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public bool cstop;
    private void OnTriggerStay(Collider other) {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(other.gameObject.CompareTag("slap")){
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
        if(cstop == false){
            if(other.gameObject.CompareTag("slap")){
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
}
