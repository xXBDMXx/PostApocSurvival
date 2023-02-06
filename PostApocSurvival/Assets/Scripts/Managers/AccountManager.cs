using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    public static AccountManager instance;

    private void Awake()
    {
        instance = this;
    }
    public PlayerAccount currentAccount;

    public void login(string username, string password, LoginHandler handler)
    {


        PlayerAccount[] accounts = AccountDatabase.instance.Accounts;

        foreach(PlayerAccount account in accounts)
        {
            if(account.username == username)
            {
                if(account.password == password)
                {
                    //Login
                    handler.SetErrorText("");
                    SuccessfulLogin(account);
                    return;
                }
                else
                {
                    //Incorrect Password
                    handler.SetErrorText("Incorrect Password");
                    return;
                }
            }
        }

        //Unable to find account
        handler.SetErrorText("Unable to find account");
    }
    public void SuccessfulLogin(PlayerAccount account)
    {
        currentAccount = account;
        //Compleate login -------------------------------------------------------- TODO
    }
}
