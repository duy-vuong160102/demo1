using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dangki : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }    
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();   
        form.AddField("name",nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/unity/sqlconnect/register.php",form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("user created successfully");
        }else
        {
            Debug.Log("User creation failed. Error#" + www.text);
        }
    }
    public void VerifyInputs()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
