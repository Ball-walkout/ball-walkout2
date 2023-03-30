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
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "ball")
        {
            StartCoroutine(GameManager.Instance.SlowMotion());
            speedbar.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}