using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour
{
    public GameObject DeathP;
    public bool inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.gameObject.CompareTag("purple") && inv == false){
            other.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Instantiate(DeathP, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Invoke("Fail", 1f);
        }
    }

    private void Fail(){
        GameManager.Instance.GameFail();
    }

    public IEnumerator QTEinv(){
        yield return new WaitForSeconds(4.0f);
        inv = false;
    }
}