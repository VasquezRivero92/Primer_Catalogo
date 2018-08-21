using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour {

    public GameObject LoginPanel;
    public GameObject RegPanel;
    public GameObject PrincipalPanel;

    public InputField login_email;
    public InputField login_pass;

    public InputField reg_email;
    public InputField reg_pass;
    public InputField reg_repass;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void MostrarLogin(){
        MostrarPanel(LoginPanel);
    }

    public void MostrarResgitro(){
        MostrarPanel(RegPanel);
    }

    public void MostrarPrincipal(){
        MostrarPanel(PrincipalPanel);
    }

    public void MostrarPanel(GameObject Panel){
        LoginPanel.SetActive(false);
        RegPanel.SetActive(false);
        PrincipalPanel.SetActive(false);

        Panel.SetActive(true);
    }
}
