using System.Collections;
using UnityEngine;

public class SwipeCamera : MonoBehaviour
{
    [SerializeField] private float _dragSpeed = 2f;
    [SerializeField] private bool isDrag;

    private InputManager _inputManager;
    private float _rotX;
    private float _rotY;
    private bool wereDragging;
    private float _slideSpeed = 10f;


    public float DragSpeed { get; private set; }

    private void Awake()
    {
        _inputManager = GetComponentInParent<InputManager>();
    }

    private void Update()
    {
        isDrag = _inputManager.IsDragging;

        if (_inputManager.IsDragging)
        {

            _rotX += Input.GetAxis("Mouse X") * _dragSpeed;
            _rotY -= Input.GetAxis("Mouse Y") * _dragSpeed;

            _rotY = Mathf.Clamp(_rotY, -80f, 80f);

            transform.eulerAngles = new Vector3(_rotY, _rotX, 0);


            wereDragging = true;
            Invoke("TurnDraggingOff", 0.3f);
        }


        if(!_inputManager.IsDragging && wereDragging)
        {

            // find out new position after letting go of drag
            //Vector3 newPosition = new Vector3(0f, 0f, 0f);

            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newPosition, _slideSpeed * Time.deltaTime);
        }


        
    }

    private void TurnDraggingOff()
    {
        wereDragging = false;
    }
}
