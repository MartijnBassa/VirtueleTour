using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next360Photo : MonoBehaviour
{

    [SerializeField] private Material[] _equirectangularPhotoMaterials;
    [SerializeField] private GameObject _equirectangularPhotoSphere;

    [SerializeField] private int _photoIndex = 0;

    private void Update()
    {
        
    }

    public void NextPhoto()
    {

        _photoIndex++;     
        if(_photoIndex > _equirectangularPhotoMaterials.Length - 1)
        {
            _photoIndex = 0;
        }

        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material = _equirectangularPhotoMaterials[_photoIndex];

    }


}
