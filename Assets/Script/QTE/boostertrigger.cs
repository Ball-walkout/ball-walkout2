using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boostertrigger : MonoBehaviour
{
    public GameObject speedbar;
    public GameObject speedbararr;
    private TouchMove ball;
    private void Start() {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
        speedbar = GameObject.Find("speedbarmove").transform.Find("tbeasy").gameObject;
        speedbararr = GameObject.Find("speedarr").transform.Find("speedbararr").gameObject;
    }
    void OnTriggerEnter(Collider other) {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == false && 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == false){
            if(other.gameObject.name == "ball")
            {
                GameManager.Instance.SlowMotion();
                speedbar.SetActive(true);
                speedbararr.GetComponent<MeshRenderer>().enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
}