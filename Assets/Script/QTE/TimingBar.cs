using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timingbar : MonoBehaviour
{
    public GameObject timing_bar;
    public GameObject timingbararr;
    public GameObject speedbar;
    public GameObject speedbararr;
    private TouchMove ball;
    arrMove aM;
    // Start is called before the first frame update
    void OnEnable()
    {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
        aM = GameObject.Find("timingarr").GetComponent<arrMove>();
        StartCoroutine(timingbarC());
        if(ball.QTE == true)
            ball.StopTouch();
        if(ball.canForward == true)
            ball.Rallentare();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && timing_bar.activeSelf == true){
            StopCoroutine(timingbarC());
            aM.speed = 0;
            timing_bar.SetActive(false);
            timingbararr.GetComponent<MeshRenderer>().enabled = false;
            speedbar.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    IEnumerator timingbarC()
    {
        yield return new WaitForSeconds(3.0f);
        aM.speed = 0;
        //Debug.Log(timingbararr.transform.parent.transform.rotation.z);
        timing_bar.SetActive(false);
        timingbararr.GetComponent<MeshRenderer>().enabled = false;
        speedbar.SetActive(true);
        speedbararr.GetComponent<MeshRenderer>().enabled = true;
    }

    public void delayturn(){
        if(timingbararr.transform.parent.transform.rotation.z > 0)
            ball.MoveRight(800f);
        else
            ball.MoveLeft(800f);
        aM.speed = 300.0f;
    }
}