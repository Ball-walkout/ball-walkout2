using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class speedtrigger : MonoBehaviour
{
    speedbar circle;
    TouchMove TM;
    PathFollower PF;
    float tempSpeed;
    public Transform boosterP1, boosterP2;
    private Transform tempParticle;
    public GameObject[] speedtext;
    TimingBar Tb;
    void OnTriggerStay(Collider other) {
        if(circle.onclick == true){
            if(gameObject.name == "Fast1"){
                
                tempSpeed = 5f;
                tempParticle = boosterP1;
                Tb.delayturn();
                speedtext[0].SetActive(true);
                StartCoroutine(Text(0));
            }

            else if(gameObject.name == "Fast2"){
                
                tempSpeed = 3f;
                tempParticle = boosterP2;
                Tb.delayturn();
                speedtext[1].SetActive(true);
                StartCoroutine(Text(1));
            }

            if(gameObject.name == "Fast3"){
                
                // 점프 없이 즉각 속도 느려지기
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.3f);
                PF.speed = 3;
                speedtext[2].SetActive(true);
                StartCoroutine(Text(2));
            }

            else if(gameObject.name == "Fast4"){
                GameObject.Find("Enemy").transform.position = GameObject.Find("ball").transform.position + new Vector3(0, 0, 8f);
                // 점프 없이 즉각 속도 멈추기. 다시 가속 할 일 없다.
                PF.speed = 0;
                TM.rig.velocity = Vector3.zero * PF.speed;
                TM.Rallentare();
                speedtext[3].SetActive(true);
                StartCoroutine(Text(3));
        
            }
            
            // 점프 후 부스터 효과 (FAST1, FAST2)
            else{
                TM.rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
                StartCoroutine(Booster(tempParticle));
            }
            
            circle.onclick = false;
            GameManager.Instance.TurnOnTime();
        }
    }

    public AudioSource boostBGM;
    Vector3 saveVelocity;
    float saveY;
    IEnumerator Text(int i){
        yield return new WaitForSeconds(0.5f);
        speedtext[i].SetActive(false);

    }
    IEnumerator Booster(Transform effect)
    {
        // 공이 위로 뜰 때는 기다리기
        while(TM.rig.velocity.y > 0)
        {
            yield return new WaitForSeconds(1f);
        }

        // 중력 끄고 3초동안 부스터 효과 (속도는 눈금에 따라)
        int stop=0;
        TM.rig.useGravity = false;
        // **부스터 파티클 및 사운드**
        effect.gameObject.SetActive(true);
        boostBGM.Play();
        saveVelocity = TM.rig.velocity;
        //TM.rig.AddForceAtPosition(TM.direction, TM.transform.position);
        TM.rig.AddForce(new Vector3(0,0,-1));
        TM.rig.velocity = new Vector3 (TM.rig.velocity.x, 0f, TM.rig.velocity.z);
        TM.rig.velocity = TM.rig.velocity * tempSpeed;
        while(stop < 2)
        {
            stop++;
            yield return new WaitForSeconds(1f);
        }
        // 중력과 공 원래 속도로 되돌리기
        TM.rig.useGravity = true;
        TM.rig.velocity = saveVelocity;
        PF.speed = 18;
        effect.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
        circle = GameObject.Find("speedbarmove").transform.Find("speedbar").GetComponent<speedbar>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
        Tb = GameObject.Find("timingbarmove").transform.Find("timingbar").GetComponent<TimingBar>();
    }
}
