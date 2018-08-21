using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthLogin : MonoBehaviour {

    UILogin authUI;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    // Use this for initialization
    void Start () {
        authUI = GetComponent<UILogin>();
        InitializeFirebase();
    }

    void OnDestroy() {
        auth.StateChanged -= AuthStateChanged;
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                //displayName = user.DisplayName ?? "";
                //emailAddress = user.Email ?? "";
                //photoUrl = user.PhotoUrl ?? "";
            }
        }
    }

    public void LoginAccount() {
        tryloginfirebaseauth(authUI.login_email.text, authUI.login_pass.text);
    }

    public void CreateAccount() {
        trycreatefirebaseauth(authUI.reg_email.text, authUI.reg_pass.text, authUI.reg_repass.text);
    }

    public void CerrarAccount()
    {
        auth.SignOut();
        authUI.MostrarLogin();
    }

    private void tryloginfirebaseauth(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            authUI.MostrarPrincipal();
            authUI.login_email.text = newUser.Email;
        });
    }

    private void trycreatefirebaseauth(string email, string password, string repassword)
    {
        if (password != repassword) { Debug.Log("no son iguales"); return; }
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            authUI.MostrarLogin();
        });
    }
}
