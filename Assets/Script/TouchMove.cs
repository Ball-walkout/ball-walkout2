using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 모바일 터치 이동 구현 참고 링크
// https://www.engedi.kr/unity/?q=YToxOntzOjEyOiJrZXl3b3JkX3R5cGUiO3M6MzoiYWxsIjt9&bmode=view&idx=3955143&t=board
public class TouchMove : MonoBehaviour
{
    [SerializeField] private Transform roadFollower;
    private Transform obj_pos;
    [SerializeField] private Animator anim;
    public float speed = 4f;
    public Rigidbody rig;
    public bool QTE;
    private void Start() {
        // 초기 물리 방향 설정
        rig = GetComponent<Rigidbody>();
        QTE = true;
        obj_pos = roadFollower;
        
        rig.AddForce(new Vector3(0,0,-1) * speed);
    }
    public Vector3 direction;
    public bool canForward=true;
    void Touch()
    {
        if (Input.touchCount > 0)
        {
            // 터치 끝났을 때
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                
                // 오른쪽 터치 시 오른쪽으로 이동
                if (Input.GetTouch(0).position.x > (Screen.width/2))
                {
                    rig.velocity = Vector3.Lerp(Vector3.zero, rig.velocity, 0.5f);
                    UpdateLeft();
                    rig.AddForce(left * 20f);
                    Invoke("Accelerate", 0.5f);
                }
                // 왼쪽 터치 시 왼쪽으로 이동
                else
                {
                    rig.velocity = Vector3.Lerp(Vector3.zero, rig.velocity, 0.5f);
                    UpdateRight();
                    rig.AddForce(right* 20f);
                    Invoke("Accelerate", 0.5f);
                }
            }
        }
    }

    // 터치 비활성화
    public void StopTouch()
    {
        print("QTE: FALSE");
        QTE = false;
    }

    // 터치 활성화
    public void EnTouch()
    {
        print("QTE: TRUE");
        QTE = true;
    }


    // 점프
    private Vector2 startTouchPos, endTouchPos;
    private bool canJump=false;
    private void FixedUpdate() {
        // 직진
        if(canForward)
        {
            direction = roadFollower.position - transform.position;
            rig.AddForceAtPosition(direction, transform.position);
            //rig.AddForce(new Vector3(0,0,-1) * speed);
        }

        if(QTE){
            //점프
            TouchCheck();

            //좌우 움직이기
            Touch();
        }
        JumpAllowed();
    }
    void TouchCheck()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;

            if(endTouchPos.y - startTouchPos.y > 70f && rig.velocity.y<=5)
            {
                canJump = true;
            }
        }
    }

    public AudioSource jumpBGM;
    public void JumpAllowed()
    {
        if(canJump)
        {
            StopTouch();
            rig.velocity = Vector3.Lerp(Vector3.zero, rig.velocity, 0.8f);
            rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
            jumpBGM.Play();
            canJump=false;
            Invoke("EnTouch", 0.5f);
        }
    }

    // 가속
    public void Accelerate()
    {
        print("Accelerated");
        canForward = true;
    }
    // 가속 멈추기
    public void Rallentare()
    {
        rig.velocity = Vector3.zero;
        print("Rallentared");
        canForward = false;
    }

    // 왼쪽으로 일정 움직이기
    public void MoveLeft(float scale)
    {
        print("MoveLeft");
        UpdateLeft();
        rig.velocity = Vector3.Lerp(Vector3.zero, rig.velocity, 0.5f);
        rig.AddForce(left * scale);
        Invoke("Accelerate", 1f);
        Invoke("EnTouch", 1f);
    }
    // 오른쪽으로 일정 움직이기
    public void MoveRight(float scale)
    {
        print("MoveRight");
        UpdateRight();
        rig.velocity = Vector3.Lerp(Vector3.zero, rig.velocity, 0.5f);
        rig.AddForce(right * scale);
        Invoke("Accelerate", 1f);
        Invoke("EnTouch", 1f);
    }

    [HideInInspector]
    public Vector3 left, right;
    public Vector3 UpdateLeft()
    {
        var quaternion = Quaternion.Euler(0, 90, 0);
        Vector3 newDirection = quaternion * direction;
        newDirection.y = 0f;
        left = newDirection;
        return newDirection;
    }
    public Vector3 UpdateRight()
    {
        var quaternion = Quaternion.Euler(0, -90, 0);
        Vector3 newDirection = quaternion * direction;
        newDirection.y = 0f;
        right = newDirection;
        return newDirection;
    }
}
