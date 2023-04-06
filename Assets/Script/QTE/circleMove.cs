using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMove : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public Vector3 direction;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 1f);
        speed = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == false && 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == false){
            Vector3 temp = gameObject.transform.position;
            temp.x = target.position.x + distance.x;
            temp.y = target.position.y + distance.y;
            gameObject.transform.position = temp;
            gameObject.transform.Translate(direction * Time.deltaTime * speed);
        }
        else{
            gameObject.transform.position = target.position + distance;
        }
    }
}
