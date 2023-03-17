using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrtrigger : MonoBehaviour
{
    arrMove arr;
    void OnTriggerEnter(Collider other) {
        if(other.name == "timingbararr"){
            if(arr.direction == new Vector3(1f, 0f, 0f)){
                arr.direction = new Vector3(-1f, 0f, 0f);
            }
            else{
                arr.direction = new Vector3(1f, 0f, 0f);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        arr = GameObject.Find("timingarr").GetComponent<arrMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
