using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrtrigger : MonoBehaviour
{
    circleMove circle;
    void OnTriggerEnter(Collider other) {
        if(other.name == "speedbararr" && (gameObject.name == "Top" || gameObject.name == "Bottom")){
            if(circle.direction == new Vector3(1, 0, 0f)){
                circle.direction = new Vector3(-1, 0, 0f);
            }
            else{
                circle.direction = new Vector3(1, 0, 0f);
            }
        }
    }
    void Start()
    {
        circle = GameObject.Find("speedarr").GetComponent<circleMove>();
    }
}
