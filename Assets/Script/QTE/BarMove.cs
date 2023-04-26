using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class BarMove : MonoBehaviour
{
   
   Transform target;
   public Vector3 distance;
   public Vector3 distance_rot;
   Vector3 temp_rot;
   Vector3 temp_pos;
   PathFollower pathFollower;
   private void Start() {
      target = GameObject.Find("ball").transform;
      pathFollower = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
   }
   void Update()
   {
     //gameObject.transform.position = pathFollower.pathCreator.path.GetPointAtDistance(pathFollower.distanceTravelled, pathFollower.endOfPathInstruction);
     gameObject.transform.rotation = pathFollower.pathCreator.path.GetRotationAtDistance(pathFollower.distanceTravelled, pathFollower.endOfPathInstruction);
     /*temp_pos = gameObject.transform.position;
     temp_pos.x = target.position.x + distance.x;
     temp_pos.y = target.position.y + distance.y;
     temp_pos.z = target.position.z + distance.z;
     gameObject.transform.position = temp_pos;*/
     Quaternion a = gameObject.transform.localRotation;
     temp_rot = a.eulerAngles;
     temp_rot.y -= distance_rot.y;
     temp_rot.z += distance_rot.z;
     gameObject.transform.rotation = Quaternion.Euler(temp_rot);
     gameObject.transform.position = target.position + distance;
   }
}
