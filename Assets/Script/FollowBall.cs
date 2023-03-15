using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ball;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = ball.transform.position + new Vector3(0f, 0.8f, 0f);
    }
}
