using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using PathCreation.Examples;

public class enemyMove : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼
    public float dampSpeed;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.
    public Rigidbody rig;
    PathFollower PF;
    Vector3 distance;
    Vector3 temp;

    void Start() {
      rig = GetComponent<Rigidbody>();
      dampSpeed = 3;
      PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
      StartCoroutine(speed());
      distance = new Vector3(0, 0, 5.0f);
    }
    public bool canTrace = true;
    void Update () {
      if(Vector3.Distance(gameObject.transform.position, target.position) >= 190){
        gameObject.transform.position = target.position + new Vector3(0, 0, 30f);
      }
      if(canTrace)
      {
          transform.LookAt(target);
          transform.position = Vector3.MoveTowards(transform.position, target.position, dampSpeed * Time.deltaTime);
      }
      // BallManager Collider 충돌 시 GameFail 부르는 거로 수정함
      // if(Vector3.Distance(target.position, this.transform.position) < 2){
      //   GameManager.Instance.GameFail();
      // }
    }
    IEnumerator speed()
    {
      while(dampSpeed < 15)
      {
          yield return new WaitForSeconds(3.0f);
          dampSpeed += 3;
      }
    }

    private void OnCollisionEnter(Collision other) {
      if(other.collider.gameObject.tag == "Obstalce" || other.collider.gameObject.tag == "purple"){
        other.collider.gameObject.GetComponent<MeshCollider>().isTrigger = true;
      }
      else if(other.collider.gameObject.tag == "slap"){
        other.collider.gameObject.GetComponent<BoxCollider>().isTrigger = true;
      }
    }
}