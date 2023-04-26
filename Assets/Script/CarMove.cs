using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    Transform ballpos;
    bool move;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        ballpos = GameObject.Find("ball").GetComponent<Transform>();
        move = false;
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, ballpos.position) <= 32 && move == false){
            if(GameObject.Find("speedbarmove").transform.Find("timingopp").gameObject.activeSelf == false){
                gameObject.transform.Translate(new Vector3(0, 0, 1f).normalized * Time.deltaTime * 10.0f);
                if(Vector3.Distance(gameObject.transform.position, pos) == 10){
                    move = true;
                }                
            }
        }
    }
}
