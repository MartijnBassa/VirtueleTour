using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _isDragging;
    private bool _turnOffUI;
    public bool IsDragging { get { return _isDragging; } set { _isDragging = value;} }
    public bool TurnOffUI { get { return _turnOffUI; } set { _turnOffUI = value; } }

    void Update()
    {
        SwipeCamera();
        ControlUI();
    }

    private void SwipeCamera()
    {
        if (Input.GetMouseButton(0))
        {
            _isDragging = true;
        }
        if (!Input.GetMouseButton(0))
        {
            _isDragging = false;
        }
    }

    private void ControlUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _turnOffUI = !_turnOffUI;
        }   

    }
}
