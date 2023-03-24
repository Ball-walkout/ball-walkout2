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
                
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 2f);
            }

            if(gameObject.name == "Fast2"){
                
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 1.5f);
            }
            
            if(gameObject.name == "Fast3"){
                
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.5f);
            }

            if(gameObject.name == "Fast4"){
                
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.3f);
            }
            
            // 원래 속도로 되돌리고, 점프
            PF.speed = 18;
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
