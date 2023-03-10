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
    public GameObject[] pos;
    public Scrollbar scrollbarspeed;
    public Scrollbar scrollbartiming;
    bool reach = false;
    bool touchspace = false;
    float fMove = 0.3f;
    public float speed;

    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Renderer>().enabled = false;
        timingBar.SetActive(true);
        timingBararr.SetActive(true);
        Stopbutton.SetActive(true);
        StartCoroutine(Stopt());
    }
    
    private TouchMove ball;
    public void buttonClick(){
        Debug.Log(scrollbartiming.value);
        Stopbutton.SetActive(false);
        fMove = 0.0f;
        if(timingBar.activeSelf == true){
            timingBar.SetActive(false);
            timingBararr.SetActive(false);
            ball = GameObject.Find("ball").GetComponent<TouchMove>();
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
            speedBar.SetActive(false);
            speedBararr.SetActive(false);
            if(scrollbarspeed.value < 0.2f){
                ball.speed = 1.0f;
            }
            else if(scrollbarspeed.value < 0.17f){
                ball.speed = 5.0f;
            }
            else if(scrollbarspeed.value < 0.34f){
                ball.speed = 15.0f;
            }
            else if(scrollbarspeed.value < 0.55f){
                ball.speed = 20.0f;
            }
            else if(scrollbarspeed.value < 0.72f){
                ball.speed = 15.0f;
            }
            else if(scrollbarspeed.value < 0.89f){
                ball.speed = 5.0f;
            }
            else{
                ball.speed = 1.0f;
            }
        }
    }

    void Update()
    {
        if(touchspace == false){
            StartCoroutine(timingbar());
        }
        else{
            StartCoroutine(speedbar());
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
    }
}