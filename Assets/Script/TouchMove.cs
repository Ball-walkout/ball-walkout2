using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 모바일 터치 이동 구현 참고 링크
// https://sunpil.tistory.com/376
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

   /* private void OnCollisionEnter(Collision other) {
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == true || 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == true){
            if(other.collider.gameObject.CompareTag("slap")){
                other.collider.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            else if(other.collider.gameObject.CompareTag("Obstacle") || other.collider.gameObject.CompareTag("purple")){
                Debug.Log(other.collider.gameObject.name);
                other.collider.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }
        }
    }*/

    private Vector2 startTouchPos, endTouchPos;
    private bool canJump = false;
    private void FixedUpdate()
    {
        // 직진
        if (canForward)
        {
            direction = roadFollower.position - transform.position;
            rig.AddForceAtPosition(direction, transform.position);
            //rig.AddForce(new Vector3(0,0,-1) * speed);
        }

        if (QTE)
        {
            //좌우 움직이기
            Touch();
        }
    }
    
    public Vector3 direction;
    public bool canForward=true;

    private Vector3 nowPos, prePos;
    private Vector3 movePosDiff;
    void Touch()
    {
        movePosDiff = Vector3.zero;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 터치 시작 시
            if (touch.phase == TouchPhase.Began)
                prePos = touch.position - touch.deltaPosition;
            // 터치 중일 때
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePosDiff = (prePos - nowPos) * Time.deltaTime;
                // 우측 이동
                if (movePosDiff.x < 0)
                {
                    MoveRight(-movePosDiff.x * 10f);
                }
                // 좌측 이동
                else
                {
                    MoveLeft(movePosDiff.x * 10f);
                }
                prePos = touch.position - touch.deltaPosition;
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
        rig.AddForce(left * scale);
        Invoke("Accelerate", 1f);
        Invoke("EnTouch", 1f);
    }
    // 오른쪽으로 일정 움직이기
    public void MoveRight(float scale)
    {
        print("MoveRight");
        UpdateRight();
        rig.AddForce(right * scale);
        Invoke("Accelerate", 1f);
        Invoke("EnTouch", 1f);
    }

    // 직진 방향 기준 좌우 좌표 업데이트
    [HideInInspector]
    public Vector3 left, right;
    public Vector3 UpdateLeft()
    {
        var quaternion = Quaternion.Euler(0, -90, 0);
        Vector3 newDirection = quaternion * direction;
        newDirection.y = 0f;
        left = newDirection;
        return newDirection;
    }
    public Vector3 UpdateRight()
    {
        var quaternion = Quaternion.Euler(0, 90, 0);
        Vector3 newDirection = quaternion * direction;
        newDirection.y = 0f;
        right = newDirection;
        return newDirection;
    }
}
