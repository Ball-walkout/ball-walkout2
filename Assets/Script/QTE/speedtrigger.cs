using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class speedtrigger : MonoBehaviour
{
    speedbar circle;
    TouchMove TM;
    PathFollower PF;
    void OnTriggerStay(Collider other) {
        if(circle.onclick == true){
            if(gameObject.name == "Fast1"){
                PF.speed = 30;
            }

            if(gameObject.name == "Fast2"){
                PF.speed = 20;
            }
            
            if(gameObject.name == "Fast3"){
                PF.speed = 10;
            }

            if(gameObject.name == "Fast4"){
                PF.speed = 2;
            }
            TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.8f);
            TM.rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
            circle.onclick = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
        circle = GameObject.Find("speedbarmove").transform.Find("speedbar").GetComponent<speedbar>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }
}
