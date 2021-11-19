using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoViewer : MonoBehaviour
{
    [SerializeField] private RawImage[] _images;
    [SerializeField] private RawImage _imageHolder;

    private int _photoIndex = 0;

    private void Update()
    {
        
    }

    public void NextPhoto()
    {
        _photoIndex++;
        _imageHolder.texture = _images[_photoIndex].texture;
    }

    public void PreviousPhoto()
    {
        _photoIndex--;
        _imageHolder.texture = _images[_photoIndex].texture;
    }
    
}
