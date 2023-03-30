using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrtrigger : MonoBehaviour
{
    circleMove circle;
    void OnTriggerEnter(Collider other) {
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
        circle = GameObject.Find("speedarr").GetComponent<circleMove>();
    }
}
