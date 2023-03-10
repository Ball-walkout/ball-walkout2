using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 모바일 터치 이동 구현 참고 링크
// https://www.engedi.kr/unity/?q=YToxOntzOjEyOiJrZXl3b3JkX3R5cGUiO3M6MzoiYWxsIjt9&bmode=view&idx=3955143&t=board
public class TouchMove : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rig;
    public Vector3[] direction;
    public int index = 0, tempindex = 0;
    private void Start() {
        rig = GetComponent<Rigidbody>();
        direction = new Vector3[4] { new Vector3(1f,rig.velocity.y,0f), new Vector3(0f,rig.velocity.y,-1f), 
        new Vector3(-1f,rig.velocity.y,0f), new Vector3(0f,rig.velocity.y,1f)};
        velocity = direction[index];
    }
    public Vector3 velocity, initialMouse;
    void Update()
    {
        // 직진
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        // 점프
        //TouchCheck();

        // 클릭 좌표로 현재 방향 기준 좌우 움직이기
        if(Input.GetMouseButtonDown(0))
        {
            initialMouse = Input.GetTouch(0).position;
            print("initialMouse.position = "+initialMouse);
        }
        if(Input.GetMouseButton(0))
        {
            if(Input.GetTouch(0).position.x < initialMouse.x)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if(Input.GetTouch(0).position.x > initialMouse.x)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }
    
    // 점프
    private Vector2 startTouchPos, endTouchPos;
    private bool canJump=false, isLeft=false, isRight=false;
    private void FixedUpdate() {
        //JumpAllowed();
    }
    void TouchCheck()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
            
            // if(Input.GetTouch(0).position.x < startTouchPos.x)
            // {
            //     isLeft = true;
            // }
            // if(Input.GetTouch(0).position.x > startTouchPos.x)
            // {
            //     isRight = true;
            // }
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
            rig.AddForce(Vector3.up * 100f);
            canJump=false;
        }
        // if(isLeft)
        // {
        //     rig.AddForce(Vector3.left * 100f);
        //     isLeft=false;
        // }
        // if(isRight)
        // {
        //     rig.AddForce(Vector3.right * 100f);
        //     isRight=false;
        // }
    }

    // Curved Rail 공 직진 방향 전환
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Left")
        {
            TurnLeft();
        }
        else if(other.tag == "Right")
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        index = index!=0 ? index-1 : 3;
        velocity = direction[index];
    }

    public void TurnRight()
    {
        index = index!=3 ? index+1 : 0;
        velocity = direction[index];
    }

    public void Jump()
    {
        rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
        
    }

}
    
    

    /*
    void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        //objPos.z = 0;
        objPos.y = -1.85f;
        transform.position = objPos;
    }
    */
    /*GameObject objectHitPostion;
    RaycastHit hitRay, hitLayerMask;

    private void OnMouseUp()
    {
        this.transform.parent = null;
        Destroy(objectHitPostion);
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitRay))
        {
            objectHitPostion = new GameObject("HitPosition");
            objectHitPostion.transform.position = hitRay.point;
            this.transform.SetParent(objectHitPostion.transform);
        }
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Rail");
        if(Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
        {
            float H = Camera.main.transform.position.y;
            float h = objectHitPostion.transform.position.y;

            Vector3 newPos 
            	= (hitLayerMask.point * (H - h) + Camera.main.transform.position * h) / H;

            objectHitPostion.transform.position = newPos;
        }
    }*/    
   /* private Vector3 mOffset;
    private float mZCoord;
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.y = mZCoord;


        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    void OnMouseDrag()

    {
        Vector3 objectPos = GetMouseAsWorldPoint() + mOffset;
        objectPos.z = 0.1f;
        transform.position = objectPos;
    }*/

    /*
    Transform tr;
    private Vector3 initTouchPos;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            initTouchPos = Input.mousePosition;
            initTouchPos.y = 10;
            initTouchPos = Camera.main.ScreenToWorldPoint(initTouchPos);
        }

        if(Input.GetMouseButtonDown(0)){
            Vector3 movedPoint = Input.mousePosition;
            movedPoint.y = 10;
            movedPoint = Camera.main.ScreenToWorldPoint(initTouchPos);

            Vector3 diffPos = movedPoint - initTouchPos;
            diffPos.y = 0;

            initTouchPos = Input.mousePosition;
            initTouchPos.y = 10;
            initTouchPos = Camera.main.ScreenToWorldPoint(initTouchPos);

            tr.transform.position = new Vector3(Mathf.Clamp(tr.transform.position.x + diffPos.x, -3.5f, 3.5f),
                tr.transform.position.y, Mathf.Clamp(tr.transform.position.z + diffPos.z, -4.5f, 4.5f));
        }
    }*/
    /*
    private float Speed = 0.25f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;
    public Transform player;

    //void Update()
   // {
        
        float distance = 10;

        void OnMouseDrag()
        {
            print("Drag!!");
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, 
    Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        /*if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch (0);
            if(touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                player.transform.Translate(movePos); 
                prePos = touch.position - touch.deltaPosition;
            }
        }
    }
    
    public float speed = 5f;
    private Rigidbody rig;
    public float jumpForce = 1.0f;
    public bool isRale = true;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Touch();
    }
    

    void Touch()
    {
        if (Input.touchCount > 0 && isRale)
        {
            // 터치 끝났을 때
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Debug.Log("Ended - 손가락이 화면 위를 벗어나 떨어지게 된 그 순간, 터치가 끝난 상태: " + Input.GetTouch(0).position);
                // 왼쪽 터치 시 왼쪽으로 이동
                if (Input.GetTouch(0).position.x > (1920/2))
                {
                    velocity = new Vector3(Input.GetTouch(0).pressure, 0, 1);
                    velocity *= speed;
                    rig.velocity = velocity;
                } else
                // 오른쪽 터치 시 오른쪽으로 이동
                {
                    velocity = new Vector3(-Input.GetTouch(0).pressure, 0, 1);
                    velocity *= speed;
                    rig.velocity = velocity;
                }
            }
        }
    }

    public void Jump()
    {
        if(isRale)
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isRale = false;
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("rale")){
            isRale = true;
        }
    }*/