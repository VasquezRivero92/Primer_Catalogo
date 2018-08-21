using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {

    public float velocidad = 200f;

	// Use this for initialization
	void Start () {        
        Destroy(gameObject,5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
	}
    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "enemigo") {
            Destroy(gameObject);
        }
    }
}
