using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePhotoViewer : MonoBehaviour
{
    [SerializeField] private GameObject _photoViewer;

    public void OpenPhoto()
    {
        _photoViewer.SetActive(true);
    }
}
