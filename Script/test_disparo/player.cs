using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Disparo playerdispara;
    // Use this for initialization
    private void Awake()
    {
        playerdispara = GetComponentInChildren<Disparo>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(1)) {
            playerdispara.disparar = true
                ;
        }        else {
            playerdispara.disparar = false;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame

}
