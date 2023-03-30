using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrtrigger : MonoBehaviour
{
    circleMove circle;
    void OnTriggerEnter(Collider other) {
       /* if(other.name == "timingbararr" && (gameObject.name == "Right" || gameObject.name == "Left")){
            if(arr.direction == new Vector3(0f, 0f, 1f)){
                arr.direction = new Vector3(0f, 0f, -1f);
            }
            else{
                arr.direction = new Vector3(0f, 0f, 1f);
            }
        }*/
        if(other.name == "speedbararr" && (gameObject.name == "Top" || gameObject.name == "Bottom")){
            if(circle.direction == new Vector3(0, 0, 1f)){
                circle.direction = new Vector3(0, 0, -1f);
            }
            else{
                circle.direction = new Vector3(0, 0, 1f);
            }
        }
    }
    void Start()
    {
     //   arr = GameObject.Find("timingarr").GetComponent<arrMove>();
        circle = GameObject.Find("speedarr").GetComponent<circleMove>();
    }
}
