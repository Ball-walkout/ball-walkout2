using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingBar : MonoBehaviour
{
    public GameObject timingBar;
    public GameObject timingBararr;
    public GameObject speedBar;
    public GameObject speedBararr;
    public GameObject[] pos;
    public bool reach = false;
    public bool touchspace = false;
    public float speed;
    void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Renderer>().enabled = false;
        timingBar.SetActive(true);
        timingBararr.SetActive(true);
    }

    void Update()
    {
        if(timingBararr.activeSelf == true){
            StartCoroutine(timingbar());
        }
        else{
            StopCoroutine(timingbar());
            StartCoroutine(speedbar());
        }
        
    }

//    IEnumerator timingbar;

    IEnumerator timingbar(){
        yield return null;
        float fMove = 0.3f;
        Vector3 sbarpos = timingBararr.transform.localPosition;
        if(sbarpos.x <= 400 && !reach && !touchspace){
            timingBararr.transform.localPosition -= new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            if(sbarpos.x == -360){
                reach = true;
            }
        }
        else{
            timingBararr.transform.localPosition += new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            if(sbarpos.x == 360){
                reach = false;
            }
        }

        //void OnTriggerStay(Collider other) {
            

        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("?");
            touchspace = true;
            if(timingBararr.transform.localPosition.x == pos[0].transform.position.x){
                speed = 5;
            }
            else if(timingBararr.transform.localPosition.x == pos[1].transform.position.x || 
            timingBararr.transform.localPosition.x == pos[2].transform.position.x){
                speed = 4;
            }
            else if(timingBararr.transform.localPosition.x == pos[3].transform.position.x || 
            timingBararr.transform.localPosition.x == pos[4].transform.position.x){
                speed = 3;
            }
            else{
                speed = 2;
        }
        }
    }

    IEnumerator speedbar(){
        yield return new WaitForSeconds(3.0f);
        timingBar.SetActive(false);
        timingBararr.SetActive(false);
        speedBar.SetActive(true);
        speedBararr.SetActive(true);
        float fMove = 0.3f;
        Vector3 barpos = speedBararr.transform.localPosition;
        if(barpos.x <= 400 && !reach){
            speedBararr.transform.localPosition -= new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            if(barpos.x == -345){
                reach = true;
            }
        }
        else{
            speedBararr.transform.localPosition += new Vector3(10.0f, 0.0f, 0.0f) * fMove;
            if(barpos.x == 345){
                reach = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
             Debug.Log("?");
            touchspace = true;
        }
    }
}