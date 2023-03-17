using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedtrigger : MonoBehaviour
{
    circleMove circle;
    TouchMove TM;
    void OnTriggerStay(Collider other) {
        if(circle.onclick == true){
            if(gameObject.name == "Fast1"){
                TM.speed = 30;
            }

            if(gameObject.name == "Fast2"){
                TM.speed = 25;
            }
            
            if(gameObject.name == "Fast3"){
                TM.speed = 20;
            }

            if(gameObject.name == "Fast4"){
                TM.speed = 15;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.Find("speedarr").GetComponent<circleMove>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
