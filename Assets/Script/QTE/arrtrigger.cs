using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrtrigger : MonoBehaviour
{
    arrMove arr;
    circleMove circle;
    void OnTriggerEnter(Collider other) {
        if(other.name == "timingbararr"){
            if(arr.direction == new Vector3(1f, 0f, 0f)){
                arr.direction = new Vector3(-1f, 0f, 0f);
            }
            else{
                arr.direction = new Vector3(1f, 0f, 0f);
            }
        }
        if(other.name == "speedbararr"){
            if(circle.direction == new Vector3(0, 0, 1f)){
                circle.direction = new Vector3(0, 0, -1f);
            }
            else{
                circle.direction = new Vector3(0, 0, 1f);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        arr = GameObject.Find("timingarr").GetComponent<arrMove>();
        circle = GameObject.Find("speedarr").GetComponent<circleMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
