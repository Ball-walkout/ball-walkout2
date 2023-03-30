using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingBar : MonoBehaviour
{
    public GameObject speedbar;
    public GameObject speedbararr;
    private TouchMove ball;
    // Start is called before the first frame update
    void OnEnable()
    {
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
        if(ball.QTE == true)
            ball.StopTouch();
        if(ball.canForward == true)
            ball.Rallentare();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && speedbar.activeSelf == true){
            speedbar.SetActive(false);
            speedbararr.GetComponent<MeshRenderer>().enabled = false;
            //Debug.Log(speedbararr.transform.parent.transform.rotation.z);
                speedbar.SetActive(true);
                speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}