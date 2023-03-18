using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMove : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public Vector3 direction;
    float speed;
    public bool onclick;
    public GameObject speed_bar;
    public GameObject speedbararr;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 1f);
        speed = 3.0f;
        onclick = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = gameObject.transform.position;
        temp.x = target.position.x + distance.x;
        temp.z = target.position.z + distance.z;
        gameObject.transform.position = temp;
        gameObject.transform.Translate(direction * Time.deltaTime * speed);
        if(speedbararr.activeSelf == true){
            //gameObject.transform.Translate(direction * Time.deltaTime * speed);
            StartCoroutine(speedbar());
        }
        if(Input.GetMouseButtonDown(0) && speedbararr.activeSelf == true){
            speed = 0;
            onclick = true;
            speed_bar.SetActive(false);
            speedbararr.SetActive(false);
        }
    }
    IEnumerator speedbar()
    {
        yield return new WaitForSeconds(3.0f);
        if(onclick == false){
            speed = 0;
            speed_bar.SetActive(false);
            speedbararr.SetActive(false);
        }
    }
}
