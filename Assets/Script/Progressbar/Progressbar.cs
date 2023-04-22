using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressbar : MonoBehaviour
{
    public RectTransform ball;
    public RectTransform enemy;
    public RectTransform road;
    public RectTransform goal;
    public float Length;
    public float le;
    public float pos;
    public float posE;
    void Start()
    {
        road = gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        ball = gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        enemy = gameObject.transform.GetChild(2).gameObject.GetComponent<RectTransform>();
        goal = gameObject.transform.GetChild(3).gameObject.GetComponent<RectTransform>();

        pos = GameObject.Find("ball").transform.position.z;
        posE = GameObject.Find("Enemy").transform.position.z;

        le = GameObject.Find("Goal").transform.position.z - GameObject.Find("ball").transform.position.z;
        road.sizeDelta = new Vector2(70, -le);
        ball.GetComponent<RectTransform>().localPosition = new Vector3(100f, le/2, -26.5f);
        enemy.GetComponent<RectTransform>().localPosition = new Vector3(100f, le/2, -26.5f);
        goal.GetComponent<RectTransform>().localPosition = new Vector3(125f, -le/2 + 80, -26.5f);
        //Length = GameObject.Find("Road Mesh Holder").GetComponent<MeshRenderer>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        ball.GetComponent<RectTransform>().localPosition = new Vector3(100f, le/2 + (pos - GameObject.Find("ball").transform.position.z), -26.5f);
        enemy.GetComponent<RectTransform>().localPosition = new Vector3(100f, le/2 + (posE - GameObject.Find("Enemy").transform.position.z), -26.5f);
    }
}
