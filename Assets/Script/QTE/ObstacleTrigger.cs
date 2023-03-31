using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject QTEP;
    private void Update() {

    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.CompareTag("Player")){
            QTEP.SetActive(true);
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }
   /* private void OnTriggerStay(Collider other) {
        if(other.gameObject.name == "Cube" && GameObject.Find("speedbarmove").transform.Find("speedbar").GetComponent<speedbar>().onclick == true){// .gameObject.CompareTag("Star")){
            QTEP.SetActive(true);
            Instantiate(QTEP, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            gameObject.SetActive(false);
        }
    }*/
}
