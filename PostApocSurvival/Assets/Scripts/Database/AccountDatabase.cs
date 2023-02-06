using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountDatabase : MonoBehaviour
{
    public static AccountDatabase instance;
    public PlayerAccount[] Accounts;

    private void Awake()
    {
        instance = this;
    }
}
