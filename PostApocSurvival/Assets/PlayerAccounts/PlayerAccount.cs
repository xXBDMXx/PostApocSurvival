using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerAccount")]
public class PlayerAccount : ScriptableObject
{
    public string username;
    public string password;

    public string displayname;
}
