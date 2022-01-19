using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoViewer : MonoBehaviour
{
    [SerializeField] private Texture[] _images;
    [SerializeField] private RawImage _imageHolder;

    [SerializeField] private int _photoIndex = 0;
    public Texture[] Images { get { return _images; } set { _images = value; } }


    public void NextPhoto()
    {
        ClampPhotoIndex(_photoIndex++);
        _imageHolder.texture = _images[_photoIndex];
    }

    public void PreviousPhoto()
    {
        ClampPhotoIndex(_photoIndex--);
        _imageHolder.texture = _images[_photoIndex];
    }

    private int ClampPhotoIndex(int value)
    {
        value = _photoIndex;

        if (value < 0)
        {
            _photoIndex = _images.Length - 1;
        }

        if(value > _images.Length - 1)
        {
            _photoIndex = 0;
        }

        return value;
    }
    
}
