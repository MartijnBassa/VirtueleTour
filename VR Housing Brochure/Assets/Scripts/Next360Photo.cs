using UnityEngine;

public class Next360Photo : MonoBehaviour
{

    //[SerializeField] private Material _equirectangularPhotoMaterial;
    [SerializeField] private GameObject _equirectangularPhotoSphere;
    [SerializeField] private Texture[] _equirectangularPhotoTextures;

    [SerializeField] private int _photoIndex = 0;

    [SerializeField] private GameObject _fadeUI;

    // Change spheres texture to new texture
    public void NextPhoto()
    {

        _photoIndex++;     
        if(_photoIndex > _equirectangularPhotoTextures.Length - 1)
        {
            _photoIndex = 0;
        }
        _fadeUI.GetComponent<Animation>().Play("FadeAnimation");
        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTextures[_photoIndex]);
        _fadeUI.GetComponent<Animation>().Play("FadeOutAnimation");

    }



}
