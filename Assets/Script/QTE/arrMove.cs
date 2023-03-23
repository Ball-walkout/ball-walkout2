using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrMove : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public Vector3 direction;
    public float speed;
    void Start()
    {
        direction = new Vector3(0f, 0f, 1f);
        speed = 300.0f;
    }
    void Update()
    {
        // 화살표 
        gameObject.transform.RotateAround(Vector3.zero, direction, Time.deltaTime * speed);
        gameObject.transform.position = target.position + distance;

        // 타이밍 바 클릭 시 방향 전환
           // speedbar.SetActive(true);
           // speedbararr.SetActive(true);
          //  speedbararr.GetComponent<MeshRenderer>().enabled = true;
        }
}