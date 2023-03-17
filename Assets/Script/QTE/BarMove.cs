using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMove : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
       // gameObject.transform.position = target.position + distance;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.position + distance;
        // x축만 이동 코드
        /*temp = gameObject.transform.position;
        temp.x = target.position.x + distance.x;
        gameObject.transform.position = temp;*/
     }
}
