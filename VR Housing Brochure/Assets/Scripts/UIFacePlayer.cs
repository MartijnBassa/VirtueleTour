using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacePlayer : MonoBehaviour
{
    [SerializeField] private Camera cameraToLookAt;

    // Make every object face the camera
    void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
