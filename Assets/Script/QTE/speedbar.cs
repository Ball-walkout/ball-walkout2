using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedbar : MonoBehaviour
{
    public bool onclick;
    public GameObject speed_bar;
    public GameObject speedbararr;
    timingbar Tb;
    private TouchMove ball;
    void OnEnable()
    {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
        Tb = GameObject.Find("timingbarmove").transform.Find("timingbar").GetComponent<timingbar>();
        StartCoroutine(speedbarC());
        onclick = false;
        if(ball.QTE == true)
            ball.StopTouch();
        if(ball.canForward == true)
            ball.Rallentare();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && speedbararr.activeSelf == true){
            onclick = true;
            Tb.delayturn();
            StopCoroutine(speedbarC());
            speed_bar.SetActive(false);
            speedbararr.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    IEnumerator speedbarC()
    {
        yield return new WaitForSeconds(3.0f);
        onclick = true;
        Tb.delayturn();
        speed_bar.SetActive(false);
        speedbararr.GetComponent<MeshRenderer>().enabled = false;
    }
}