using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.CompareTag("purple") && GameObject.Find("speedbarmove").transform.Find("tbeasy").GetComponent<speedbar>().onclick == false){
            other.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Particle").gameObject.transform.Find("DeathP").gameObject.SetActive(true);
            GameObject.Find("DeathP").gameObject.transform.position = other.collider.gameObject.transform.position;
            Invoke("Fail", 1f);
        }
    }

    private void Fail(){
        GameManager.Instance.GameFail();
    }
}