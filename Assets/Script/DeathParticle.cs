using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour
{
    public GameObject DeathP;
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
            Instantiate(DeathP, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Invoke("Fail", 1f);
        }
    }

    private void Fail(){
        GameManager.Instance.GameFail();
    }
}