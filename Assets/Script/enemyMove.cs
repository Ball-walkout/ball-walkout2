using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class enemyMove : MonoBehaviour
{
    public Transform target; // 따라갈 타겟의 트랜스 폼
    public float dampSpeed;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.

    void Start() {
      dampSpeed = 1;
      StartCoroutine(speed());
    }
    void Update () {
      transform.LookAt(target);
      if(Vector3.Distance(target.position, this.transform.position) > 10){
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * dampSpeed);
      }
      if(Vector3.Distance(target.position, this.transform.position) < 2){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    }
    IEnumerator speed()
    {
      yield return new WaitForSeconds(10.0f);
      dampSpeed += 3;
      StartCoroutine(speed());
    }
}