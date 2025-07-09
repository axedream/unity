using UnityEngine;

public class InputMouse : MonoBehaviour
{
    public event System.Action ButtonPressed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ButtonPressed?.Invoke();
        }
    }
}