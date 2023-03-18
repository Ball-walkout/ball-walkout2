using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingBar : MonoBehaviour
{
    public GameObject timingBar;
    public GameObject timingBararr;
    public GameObject speedBar;
    public GameObject speedBararr;
    bool reach = false;
    public bool touchspace = false;
    public bool buttonclick = false;
    float fMove = 0.3f;
    private TouchMove ball;
    private void Start() {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "ball")
        {
            timingBar.SetActive(true);
            //timingBararr.SetActive(true);
            timingBararr.GetComponent<MeshRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
        
    }
   
}