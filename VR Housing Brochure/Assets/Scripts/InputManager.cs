using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _isDragging;

    public bool IsDragging { get { return _isDragging; } set { _isDragging = value;} }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _isDragging = true;
        }
        if(!Input.GetMouseButton(0))
        {
            _isDragging = false;
        }
    }
}
