using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyMove : MonoBehaviour {
  public Transform target; // 따라갈 타겟의 트랜스 폼
  public float dampSpeed = 4;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.

  void Start() {

  }
  void Update () {
      Follow();
  }

  void Follow(){
    if (Vector3.Distance(target.position, this.transform.position) > 4){
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);
    }
    transform.LookAt(target);
  }
}