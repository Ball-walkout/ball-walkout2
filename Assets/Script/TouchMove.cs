using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 모바일 터치 이동 구현 참고 링크
// https://www.engedi.kr/unity/?q=YToxOntzOjEyOiJrZXl3b3JkX3R5cGUiO3M6MzoiYWxsIjt9&bmode=view&idx=3955143&t=board
public class TouchMove : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody rig;
    public Vector3 forward, left, right;
    private void Start() {
        // 초기 물리 방향 설정
        rig = GetComponent<Rigidbody>();
        forward = new Vector3(1f, 0f, 0f);
        left = new Vector3(0f, 0f, 1f);
        right = new Vector3(0f, 0f, -1f);
    }
    public Vector3 velocity, initialMouse;
    private bool canForward=true;
    void Update()
    {
        // 직진
        if(canForward)
        rig.AddForce(forward * speed);

        // 점프
        TouchCheck();

        // 좌우 움직이기
        Touch();
    }
    
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
                    print("오른쪽 클릭");
                    canForward = false;
                    rig.AddForce(right * 800f);
                    //canForward= true;
                }
                // 왼쪽 터치 시 왼쪽으로 이동
                else
                {
                    print("왼쪽 클릭");
                    canForward = false;
                    rig.AddForce(left * 800f);
                    //canForward= true;
                }
            }
        }
    }

    // 점프
    private Vector2 startTouchPos, endTouchPos;
    private bool canJump=false;
    private void FixedUpdate() {
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

            if(endTouchPos.y - startTouchPos.y > 30f && rig.velocity.y<=0)
            {
                canJump = true;
            }
        }
    }
    void JumpAllowed()
    {
        if(canJump)
        {
            canForward = false;
            rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
            print("점프");
            canJump=false;
            //canForward = true;
        }
    }

    // Curved Rail 공 직진 방향 전환
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Left")
        {
            canForward = false;
            TurnLeft();
            canForward = true;
        }
        else if(other.tag == "Right")
        {
            canForward = false;
            TurnRight();
            canForward = true;
        }
    }

    public void TurnLeft()
    {
        Vector3 temp;
        temp = forward;
        forward = left;
        right = temp;
        left = -temp;
    }

    public void TurnRight()
    {
        Vector3 temp;
        temp = forward;
        forward = right;
        left = temp;
        right = -temp;
    }

    public void Jump()
    {
        rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
        
    }

}
    