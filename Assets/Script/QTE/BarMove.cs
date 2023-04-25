using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class BarMove : MonoBehaviour
{
   
   Transform target1;
   Transform target2;
   public Vector3 distance;
   Vector3 temp1;
   public Vector3 temp;
   private void Start() {
      target1 = GameObject.Find("RoadFollower").transform;
      target2 = GameObject.Find("ball").transform;
   }
   void Update()
   {
      temp = gameObject.transform.position;
      temp.x = target1.position.x + distance.x;
      temp.y = target1.position.y + distance.y;
      temp.z = target2.position.z + distance.z;
      gameObject.transform.position = temp;
     // gameObject.transform.position = target.position + distance; // * GameObject.Find("timingarr").GetComponent<arrMove>().speed;
   //  gameObject.transform.rotation = PathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
      Vector3 RFt = new Vector3(gameObject.transform.position.x, GameObject.Find("RoadFollower").transform.position.y, 
      gameObject.transform.position.z);
      transform.LookAt(RFt);
      temp1.x = gameObject.transform.rotation.x + 180f;
      temp1.y = gameObject.transform.rotation.y + 95f;
      gameObject.transform.rotation = Quaternion.Euler(temp1);
      // x축만 이동 코드
      /*temp = gameObject.transform.position;
      temp.x = target.position.x + distance.x;
      gameObject.transform.position = temp;*/
   }
}
