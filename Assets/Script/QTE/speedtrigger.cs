using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedtrigger : MonoBehaviour
{
    speedbar circle;
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
            TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.8f);
            TM.rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
            circle.onclick = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.Find("speedbarmove").transform.Find("speedbar").GetComponent<speedbar>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }
}
