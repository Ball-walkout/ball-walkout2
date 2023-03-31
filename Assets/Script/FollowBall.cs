using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ball;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + new Vector3(2.76f, 10.3f, 27.49f);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, 180f+ball.rotation.y, transform.rotation.z);
    }
}
