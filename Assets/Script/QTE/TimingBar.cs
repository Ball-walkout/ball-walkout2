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
    public GameObject Stopbutton;
    bool reach = false;
    public bool touchspace = false;
    public bool buttonclick = false;
    float fMove = 0.3f;
    private TouchMove ball;
    private void Start() {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
    }
    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Renderer>().enabled = false;
        timingBar.SetActive(true);
        timingBararr.SetActive(true);
        Stopbutton.SetActive(true);
        //StartCoroutine(Stopt());
    }
   /* public void buttonClick(){
        buttonclick = true;
        Stopbutton.SetActive(false);
        fMove = 0.0f;
        if(timingBar.activeSelf == true){
            StartCoroutine(Stopb());
            timingBar.SetActive(false);
            timingBararr.SetActive(false);
            if(scrollbartiming.value < 0.03f){
                ball.TurnLeft();
            }
            else if(0.03f <= scrollbartiming.value && scrollbartiming.value < 0.23f){
                ball.TurnLeft();
                //ball.rig.velocity += ball.direction[ball.index] * (ball.speed/2);
            }
            else if(0.23f <= scrollbartiming.value && scrollbartiming.value < 0.17f){
                ball.TurnLeft();
                //ball.rig.velocity += new Vector3(0f, -6f, 1f) * (ball.speed/2);
            }
            else if(0.17f <= scrollbartiming.value && scrollbartiming.value < 0.61f){
                //ball.TurnLeft();
                //ball.rig.velocity += new Vector3(0f, -6f, 1f) * (ball.speed/2);
            }
            else if(0.61f <= scrollbartiming.value && scrollbartiming.value < 0.8f){
                ball.TurnRight();
                //ball.rig.velocity += new Vector3(0f, -6f, 1f) * (ball.speed/2);
            }
            else if(0.8f <= scrollbartiming.value && scrollbartiming.value < 0.96f){
                ball.TurnRight();
                //ball.rig.velocity += new Vector3(0f, -6f, 1f) * (ball.speed/2);
            }
            else{
               ball.TurnRight();
            }
        }
        if(speedBar.activeSelf == true){
            touchspace = false;
            speedBar.SetActive(false);
            speedBararr.SetActive(false);
            if(scrollbarspeed.value < 0.2f){
                ball.speed = 5.0f;
            }
            else if(scrollbarspeed.value < 0.17f){
                ball.speed = 10.0f;
            }
            else if(scrollbarspeed.value < 0.34f){
                ball.speed = 18.0f;
            }
            else if(scrollbarspeed.value < 0.55f){
                ball.speed = 25.0f;
            }
            else if(scrollbarspeed.value < 0.72f){
                ball.speed = 18.0f;
            }
            else if(scrollbarspeed.value < 0.89f){
                ball.speed = 10.0f;
            }
            else{
                ball.speed = 5.0f;
            }
            StartCoroutine(speedorigin());
        }
    }

    IEnumerator speedorigin(){
        yield return new WaitForSeconds(5.0f);
        ball.speed = 10.0f;
    }

    void Update()
    {
        if(Stopbutton.activeSelf == true){
            if(touchspace == false){
                StartCoroutine(timingbar());
            }
            else{
                StartCoroutine(speedbar());
            }
        }
    }

    IEnumerator timingbar(){
        yield return null;
        Vector3 sbarpos = timingBararr.transform.eulerAngles;
        if(sbarpos.z >= 0 && !reach){
            scrollbartiming.value += 0.009f * fMove;
            timingBararr.transform.Rotate(new Vector3(0.0f, 0.0f, -2.0f) * fMove);
            if(sbarpos.z == 235.4f){
                reach = true;
            }
        }
        else{
            scrollbartiming.value -= 0.009f * fMove;
            timingBararr.transform.Rotate(new Vector3(0.0f, 0.0f, 2.0f) * fMove);
            if(sbarpos.z >= 126.2f && sbarpos.z <= 230.0f){
                reach = false;
            }
        }
    }
    IEnumerator Stopt(){
        yield return new WaitForSeconds(3.0f);
        touchspace = true;
        if(buttonclick == false){
            timingBar.SetActive(false);
            timingBararr.SetActive(false);
            speedBar.SetActive(true);
            speedBararr.SetActive(true);
            StopCoroutine(timingbar());
            fMove = 0.3f;
        }
    }
    IEnumerator Stopb(){
        yield return null;
        Stopbutton.SetActive(true);
        touchspace = true;
        timingBar.SetActive(false);
        timingBararr.SetActive(false);
        speedBar.SetActive(true);
        speedBararr.SetActive(true);
        StopCoroutine(timingbar());
        fMove = 0.3f;
    }

    IEnumerator speedbar(){
        yield return null;
        Vector3 barpos = speedBararr.transform.localPosition;
        if(barpos.x <= 400 && !reach){
            speedBararr.transform.localPosition -= new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            scrollbarspeed.value -= 0.017f * fMove;
            if(barpos.x == -345){
                reach = true;
            }
        }
        else{
            speedBararr.transform.localPosition += new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            scrollbarspeed.value += 0.017f * fMove;
            if(barpos.x == 345){   
                reach = false;
            }
        }
    }*/
}