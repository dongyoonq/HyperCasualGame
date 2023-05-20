using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    public UnityEvent OnStarted;

    void OnTouch(InputValue inputValue)
    {
        OnStarted?.Invoke();
    }
}

