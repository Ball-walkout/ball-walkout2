using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrMove : MonoBehaviour
{
    public Transform target;
    public Transform point;
    public Vector3 distance;
    public Vector3 direction;
    public float speed;
    bool onclick;
    public GameObject timing_bar;
    public GameObject timingbararr;
    public GameObject speedbar;
    public GameObject speedbararr;
    TouchMove TM;
    void Start()
    {
        direction = new Vector3(1f, 0f, 0f);
        speed = 200.0f;
        onclick = false;
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }
    void Update()
    {
        if(timing_bar.activeSelf == true){
            StartCoroutine(timingbar());
            TM.QTE = false;
            //TM.speed = 0.1f;
            //gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
        }
        gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
        gameObject.transform.position = target.position + distance;

        if(Input.GetMouseButtonDown(0) && timing_bar.activeSelf == true){
            TM.QTE = true;
            speed = 0;
            onclick = true;
            //GameObject.Find("ball").transform.Rotate(gameObject.transform.rotation.eulerAngles);
            GameObject.Find("ball").GetComponent<Rigidbody>().MoveRotation(gameObject.transform.rotation);
            Debug.Log(Vector3.Angle(gameObject.transform.rotation.eulerAngles, 
            point.transform.rotation.eulerAngles));
            timing_bar.SetActive(false);
            timingbararr.SetActive(false);
            speedbar.SetActive(true);
           // speedbararr.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    IEnumerator timingbar()
    {
        yield return new WaitForSeconds(3.0f);
        if(onclick == false){
            speed = 0;
            timing_bar.SetActive(false);
            timingbararr.SetActive(false);
            speedbar.SetActive(true);
           // speedbararr.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}