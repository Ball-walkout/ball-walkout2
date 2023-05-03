using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public int Combo_v;
    Text comboT;
    // Start is called before the first frame update
    void Start()
    {
        comboT = gameObject.GetComponent<Text>();
        Combo_v = 0;
    }

    // Update is called once per frame
    void Update()
    {
        comboT.text = Combo_v + " Combo!";
        if(GameObject.Find("Move").transform.Find("부스터").gameObject.activeSelf == false && 
        GameObject.Find("Move").transform.Find("부스터2").gameObject.activeSelf == false){
            gameObject.SetActive(false);
        }
    }
}
