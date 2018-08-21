using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class mysql_connect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(System.Environment.Version);
        mysql();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void mysql() {
        MySqlConnection conn = new MySqlConnection();
        string DataConexion = "Server=mysql.aprendiendoaprevenir.com;Database=aap_main;User ID=aap_user01;Password=Z8D_q!?qñ;";

        conn.ConnectionString = DataConexion;

        try {
            conn.Open();
            Debug.Log("Conexion establecida");
        }catch(MySqlException error){
            Debug.Log("Error = " + error);
        }
    }
}
