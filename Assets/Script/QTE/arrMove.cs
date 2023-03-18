using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrMove : MonoBehaviour
{
    public Transform target;
    public Transform point;
    public Vector3 distance;
    public Vector3 direction;
    public float speed;
    bool onclick;
    public GameObject timing_bar;
    public GameObject timingbararr;
    public GameObject speedbar;
    public GameObject speedbararr;
    private TouchMove ball;
    void Start()
    {
        direction = new Vector3(0f, 0f, 1f);
        speed = 200.0f;
        onclick = false;
        ball = GameObject.Find("ball").GetComponent<TouchMove>();
    }
    void Update()
    {
        if(timing_bar.activeSelf == true){
            // 타이밍 바 자동 끄기
            StartCoroutine(timingbar());
            // 터치 금지 & 가속 멈추기
            if(ball.QTE == true)
                ball.StopTouch();
            if(ball.canForward == true)
                ball.Rallentare();
        }

        // 화살표 
        gameObject.transform.RotateAround(target.position, direction, Time.deltaTime * speed);
        gameObject.transform.position = target.position + distance;

        // 타이밍 바 클릭 시 방향 전환
        if(Input.GetMouseButtonDown(0) && timing_bar.activeSelf == true){
            onclick = true;
            if(gameObject.transform.rotation.z > 0)
                ball.MoveLeft(800f);
            else
                ball.MoveRight(800f);
            print(gameObject.transform.rotation.z);
            
            // 끄기
            speed = 0;
            timing_bar.SetActive(false);
            timingbararr.SetActive(false);
            speedbar.SetActive(true);
           // speedbararr.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    IEnumerator timingbar()
    {
        yield return new WaitForSeconds(3.0f);
        if(onclick == false){
            speed = 0;
            timing_bar.SetActive(false);
            timingbararr.SetActive(false);
            speedbar.SetActive(true);
           // speedbararr.SetActive(true);
            speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}