using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginHandler : MonoBehaviour
{
    [SerializeField] private InputField usernameField;
    [SerializeField] private InputField passwordField;

    [SerializeField] private TMP_Text ErrorText;
    public void Login()
    {

        string username = usernameField.text;
        string password = passwordField.text;

        if (username == "")
        {
            //Username can't be left blank
            SetErrorText("Username can't be left Blank");
            return;
        }

        if (password == "")
        {
            //Password can't be left blacnk
            SetErrorText("Password can't be left Blank");
            return;
        }

        AccountManager.instance.login(username, password, this);
    }

    public void SetErrorText(string text)
    {
        ErrorText.text = text;
    }
}
