using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Sever : MonoBehaviour
{
    [SerializeField] GameObject Play;
    [SerializeField] GameObject LoginA;
    [SerializeField] TextMeshProUGUI user;

    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;

    [SerializeField] TextMeshProUGUI errorMessages;

    [SerializeField] Button loginButton;
    [SerializeField] string url;
    WWWForm form;
    // Start is called before the first frame update

    public void OnLoginButtonClicked()
    {
        loginButton.interactable = false;
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        form = new WWWForm();

        form.AddField("username", username.text);
        form.AddField("password", password.text);

        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcom panel
                    Play.SetActive(true);
                    user.text = username.text;
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                }
            }
        }

        loginButton.interactable = true;
        w.Dispose();
    }
}

