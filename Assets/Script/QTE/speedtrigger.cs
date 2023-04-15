using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class speedtrigger : MonoBehaviour
{
    speedbar circle;
    TouchMove TM;
    PathFollower PF;
    float tempSpeed;
    public Transform boosterP1, boosterP2;
    private Transform tempParticle;
    public GameObject[] speedtext;
    void Start()
    {
        PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
        circle = GameObject.Find("speedbarmove").transform.Find("tbeasy").GetComponent<speedbar>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
        boosterP1 = GameObject.Find("Move").transform.Find("부스터").transform;
        boosterP2 = GameObject.Find("Move").transform.Find("부스터2").transform;
        speedtext[0] = GameObject.Find("Canvas").transform.Find("Perfect").gameObject;
        speedtext[1] = GameObject.Find("Canvas").transform.Find("Cool").gameObject;
        speedtext[2] = GameObject.Find("Canvas").transform.Find("Bad").gameObject;
        speedtext[3] = GameObject.Find("Canvas").transform.Find("Miss").gameObject;
    }
    void OnTriggerStay(Collider other) {
        if(circle.onclick == true && other.name == "speedbararr"){
            GameManager.Instance.ReleaseSlow();
            if(gameObject.name == "Fast1"){
                tempSpeed = 3f;
                tempParticle = boosterP1;
                speedtext[0].SetActive(true);
                StartCoroutine(Text(0));
            }
            else if(gameObject.name == "Fast2"){        
                tempSpeed = 1f;
                tempParticle = boosterP2;
                speedtext[1].SetActive(true);
                StartCoroutine(Text(1));
            }
            if(gameObject.name == "Fast3"){              
              // 점프 없이 즉각 속도 느려지기
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.3f);
                PF.speed = 3;
                TM.QTE = true;
                speedtext[2].SetActive(true);
                StartCoroutine(Text(2));
            }
            else if(gameObject.name == "Fast4"){
                GameObject.Find("Enemy").transform.position = GameObject.Find("ball").transform.position + new Vector3(0, 0, 8f);
                // 점프 없이 즉각 속도 멈추기. 다시 가속 할 일 없다.
                PF.speed = 0;
                TM.rig.velocity = Vector3.zero * PF.speed;
               // TM.Rallentare();
                speedtext[3].SetActive(true);
                StartCoroutine(Text(3));
            }           
            // 점프 후 부스터 효과 (FAST1, FAST2)
            else{
              //  TM.rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
                StartCoroutine(Booster(tempParticle));
            }
            circle.onclick = false;
        }
    }

    public AudioSource boostBGM;
    float saveY;
    IEnumerator Text(int i){
        yield return new WaitForSeconds(0.5f);
        speedtext[i].SetActive(false);
    }
    IEnumerator Booster(Transform effect)
    {
        GameManager.Instance.isQTE = true;
        // 3초동안 부스터 효과 (속도는 눈금에 따라)
        int stop=0;

        // **부스터 파티클 및 사운드**
        effect.gameObject.SetActive(true);
        //    boostBGM.Play();

        // 직진 가속
        PF.speed = 80f;
        TM.rig.AddForce(TM.direction * tempSpeed * 200);
        // 회전
        while(stop < 2)
        {
            stop++;
            yield return new WaitForSeconds(1f);
        }
        // 중력과 공 원래 속도로 되돌리기
        TM.Accelerate();
        TM.EnTouch();
        //circle.onclick = false;
        effect.gameObject.SetActive(false);
        GameManager.Instance.isQTE = false;
        PF.speed = 18f;
    }

    // Start is called before the first frame update

}
