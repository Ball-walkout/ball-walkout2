using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 모바일 터치 이동 구현 참고 링크
// https://www.engedi.kr/unity/?q=YToxOntzOjEyOiJrZXl3b3JkX3R5cGUiO3M6MzoiYWxsIjt9&bmode=view&idx=3955143&t=board
public class TouchMove : MonoBehaviour
{
    void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        //objPos.z = 0;
        objPos.y = -1.85f;
        transform.position = objPos;
    }
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
}
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