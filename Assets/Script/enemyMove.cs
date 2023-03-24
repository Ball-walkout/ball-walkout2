using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using PathCreation.Examples;

public class enemyMove : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼
    public float dampSpeed;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
    PathFollower PF;
    Vector3 distance;
    Vector3 temp;

    void Start() {
      dampSpeed = 2;
      PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
      StartCoroutine(speed());
      distance = new Vector3(0, 0, 5.0f);
    }
    void Update () {
      Debug.Log(transform.position.y);
      transform.LookAt(target);
      transform.position = Vector3.MoveTowards(transform.position, target.position, dampSpeed * Time.deltaTime);
    //  if(Vector3.Distance(target.position, this.transform.position) > 5){
        // temp.x = target.position.x + distance.x;
        // temp.y = target.position.y + distance.y;
        // temp.z = target.position.z + distance.z;
        // transform.position = temp;
    //  }
     // else{
     //   transform.position = Vector3.MoveTowards(transform.position, target.position, dampSpeed * Time.deltaTime);
        //transform.position = target.position + distance;
   //   }
        //temp.x = target.position.x + distance.x;
       // temp.z = target.position.z + distance.z;
       // transform.position = temp;
        //Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);
     // }*/
      if(Vector3.Distance(target.position, this.transform.position) < 2){
        GameManager.Instance.GameFail();
      }
    }
    IEnumerator speed()
    {
      while(dampSpeed < 15)
      {
          yield return new WaitForSeconds(3.0f);
          dampSpeed += 1;
      }
    }
}