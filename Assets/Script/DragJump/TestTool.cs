using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragJump;

public class TestTool : MonoBehaviour
{
    DragJumpUtility drag;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        drag = new DragJumpUtility();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drag.GetJumpDrag())
        {
            rig.AddForce(Vector3.up * drag.GetJumpSpeed() * 100f);
            Debug.Log("Jump speed: "+drag.GetJumpSpeed().ToString());
        }
    }
}
