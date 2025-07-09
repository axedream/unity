using System;
using UnityEngine;

public class InputMouse : MonoBehaviour
{
    public event System.Action ButtonLeftPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonLeftPressed?.Invoke();
        }
    }
}