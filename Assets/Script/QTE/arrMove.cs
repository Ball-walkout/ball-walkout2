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
    TouchMove TM;
    void Start()
    {
        direction = new Vector3(1f, 0f, 0f);
        speed = 50.0f;
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }
    void Update()
    {
        gameObject.transform.position = target.position + distance;
        gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
    }
    public void StopClick(){
        speed = 0;
        //GameObject.Find("ball").transform.Rotate(gameObject.transform.rotation.eulerAngles);
        Debug.Log(Vector3.Angle(gameObject.transform.rotation.eulerAngles, 
        point.transform.rotation.eulerAngles));
    }
    
}
