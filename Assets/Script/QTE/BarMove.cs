using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMove : MonoBehaviour
{
   
   Transform target;
   public Vector3 distance;
   private void Start() {
      target = GameObject.Find("ball").transform;
   }
   void Update()
   {
      gameObject.transform.position = target.position + distance; // * GameObject.Find("timingarr").GetComponent<arrMove>().speed;
      // x축만 이동 코드
      /*temp = gameObject.transform.position;
      temp.x = target.position.x + distance.x;
      gameObject.transform.position = temp;*/
   }
}
