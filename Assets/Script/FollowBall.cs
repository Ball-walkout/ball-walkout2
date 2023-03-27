using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ball;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + new Vector3(1.44f, 14f, 27.57f);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, 180f+ball.rotation.y, transform.rotation.z);
    }
}
