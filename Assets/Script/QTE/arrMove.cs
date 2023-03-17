using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrMove : MonoBehaviour
{
    public Transform target;
    public Transform point;
    public Vector3 distance;
    public Vector3 direction;
    float speed;
    bool onclick;
    public GameObject timing_bar;
    public GameObject timingbararr;
    public GameObject speedbar;
    public GameObject speedbararr;
    void Start()
    {
        direction = new Vector3(1f, 0f, 0f);
        speed = 50.0f;
        onclick = false;
    }
    void Update()
    {
        if(timing_bar.activeSelf == true){
            StartCoroutine(timingbar());
            gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
        }
        gameObject.transform.position = target.position + distance;
        //gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
    }
    public void StopClick(){
        speed = 0;
        onclick = true;
        //GameObject.Find("ball").transform.Rotate(gameObject.transform.rotation.eulerAngles);
        Debug.Log(Vector3.Angle(gameObject.transform.rotation.eulerAngles, 
        point.transform.rotation.eulerAngles));
    }
    IEnumerator timingbar()
    {
        yield return new WaitForSeconds(3.0f);
        if(onclick == false){
            speed = 0;
        }
        timing_bar.SetActive(false);
        timingbararr.SetActive(false);
        speedbar.SetActive(true);
        speedbararr.SetActive(true);
    }
}
