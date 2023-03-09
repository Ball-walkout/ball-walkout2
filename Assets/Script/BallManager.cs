using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private PlayerCamera cam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            GameManager.Instance.SetCoin(1);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Obstacle")
        {
            // 장애물 종류별 스코어 변경 필요 **
            GameManager.Instance.SetScore(10);
            Destroy(other.gameObject, 30f);
        }
        else if(other.tag == "Left")
        {
            cam.offsetX = 0f;
            cam.offsetZ = -10f;
            StartCoroutine(Rotate(0));
        }
        else if(other.tag == "Right")
        {
            cam.offsetX = -10f;
            cam.offsetZ = 0f;
            StartCoroutine(Rotate(1));
        }
    }

    IEnumerator Rotate(int LR)
    {
        while(LR==0 && cam.transform.rotation.eulerAngles.y >= 0){
            cam.transform.RotateAround(cam.transform.position, new Vector3(0f, -1f, 0f), 1f);
            yield return null;
        }
        while(LR==1 && cam.transform.rotation.eulerAngles.y <= 90){
            cam.transform.RotateAround(cam.transform.position, new Vector3(0f, 1f, 0f), 1f);
            yield return null;
        }
    }
}
