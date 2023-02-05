using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputhandler;

    private void Awake()
    {
        inputhandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        float delta = Time.deltaTime;

        inputhandler.TickInput(delta);

    }
}
