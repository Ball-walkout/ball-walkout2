using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class circleMove : MonoBehaviour
{
    Transform target;
    public Vector3 distance;
    public Vector3 direction;
    public Vector3 distance_rot;
    float speed;
    Vector3 temp_rot;
    PathFollower pathFollower;
    // Start is called before the first frame update
    void Start()
    {
        pathFollower = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
        direction = new Vector3(1, 0, 0f);
        speed = 30.0f;
        target = GameObject.Find("speedbarmove").transform;
        gameObject.transform.position = target.position + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("speedbarmove").transform.Find("timingopp").gameObject.activeSelf == true){
            gameObject.transform.Translate(direction * Time.deltaTime * speed);
        }
        else{
            if(GameObject.Find("speedarr").transform.Find("speedbararr").gameObject.activeSelf == false){
                gameObject.transform.rotation = pathFollower.pathCreator.path.GetRotationAtDistance(pathFollower.distanceTravelled, pathFollower.endOfPathInstruction);
                Quaternion a = gameObject.transform.localRotation;
                temp_rot = a.eulerAngles;
                temp_rot.y -= distance_rot.y;
                temp_rot.z += distance_rot.z;
                gameObject.transform.rotation = Quaternion.Euler(temp_rot);
                gameObject.transform.position = target.position + distance;
           }
        }
    }
}
