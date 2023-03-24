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
    public Transform boosterP;
    void OnTriggerStay(Collider other) {
        if(circle.onclick == true){
            if(gameObject.name == "Fast1"){
                
                tempSpeed = 5f;
            }

            if(gameObject.name == "Fast2"){
                
                tempSpeed = 3f;
            }
            
            if(gameObject.name == "Fast3"){
                
                tempSpeed = 1f;
            }

            if(gameObject.name == "Fast4"){
                // 점프 없이 즉각 속도 느려지기
                TM.rig.velocity = Vector3.Lerp(Vector3.zero, TM.rig.velocity, 0.3f);
                PF.speed = 18;
            }
            
            // 점프 후 부스터 효과
            else{
                TM.rig.AddForce(Vector3.up * 70f, ForceMode.Impulse);
                StartCoroutine(Booster());
            }
            
            circle.onclick = false;
        }
    }

    public AudioSource boostBGM;
    float saveY;
    IEnumerator Booster()
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
        boosterP.gameObject.SetActive(true);
        boostBGM.Play();
        TM.rig.AddForceAtPosition(TM.direction, TM.transform.position);
        saveY = TM.rig.velocity.y;
        TM.rig.velocity = new Vector3 (TM.rig.velocity.x, 0f, TM.rig.velocity.z);
        TM.rig.velocity = TM.rig.velocity * tempSpeed;
        while(stop < 2)
        {
            stop++;
            yield return new WaitForSeconds(1f);
        }
        // 중력과 공 원래 속도로 되돌리기
        TM.rig.useGravity = true;
        TM.rig.velocity = new Vector3 (TM.rig.velocity.x, saveY, TM.rig.velocity.z);
        PF.speed = 18;
        boosterP.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        PF = GameObject.Find("RoadFollower").GetComponent<PathFollower>();
        circle = GameObject.Find("speedbarmove").transform.Find("speedbar").GetComponent<speedbar>();
        TM = GameObject.Find("ball").GetComponent<TouchMove>();
    }
}
