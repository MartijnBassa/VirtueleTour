using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next360Photo : MonoBehaviour
{

    [SerializeField] private Material _equirectangularPhotoMaterial;
    [SerializeField] private GameObject _equirectangularPhotoSphere;
    [SerializeField] private Texture[] _equirectangularPhotoTexture;

    [SerializeField] private int _photoIndex = 0;

    public void NextPhoto()
    {

        _photoIndex++;     
        if(_photoIndex > _equirectangularPhotoTexture.Length - 1)
        {
            _photoIndex = 0;
        }

        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTexture[_photoIndex]);

    }


}
