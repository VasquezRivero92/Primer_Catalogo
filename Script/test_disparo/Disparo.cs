using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {

    public bool disparar = false;

    public proyectil bala;
    public float velocidadbala;
    public float velocidaddisparo;
    public float tiempoespera;
    public Transform salidabala;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        disparar_basico();
	}
    void disparar_basico() {
        if (disparar == true) {
            tiempoespera -= Time.deltaTime;
            if (tiempoespera <= 0) {
                tiempoespera = velocidaddisparo;
                proyectil newbala = Instantiate(bala, salidabala.position, salidabala.rotation) as proyectil;
                newbala.velocidad = velocidadbala;
            }
        }
    }
}
