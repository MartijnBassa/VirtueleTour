using UnityEngine;

public class Next360Photo : MonoBehaviour
{

    //[SerializeField] private Material _equirectangularPhotoMaterial;
    [SerializeField] private GameObject _equirectangularPhotoSphere;
    [SerializeField] private Texture[] _equirectangularPhotoTextures;

    [SerializeField] private int _photoIndex = 0;

    [SerializeField] private GameObject _fadeUI;

    private string _animationOn = "FadeInAnimation";
    private string _animationOff = "FadeOutAnimation";

    // Change spheres texture to new texture
    public void NextPhoto()
    {
        CanvasAnimation(_animationOn, false);
        _photoIndex++;     
        if(_photoIndex > _equirectangularPhotoTextures.Length - 1)
        {
            _photoIndex = 0;
        }
        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTextures[_photoIndex]);
        CanvasAnimation(_animationOff, true);

    }

    private void CanvasAnimation(string text, bool fadeOut)
    {
        _fadeUI.SetActive(true);
        _fadeUI.GetComponent<Animation>().Play(text);

        if(fadeOut)
            Invoke("TurnOffCanvas", 1.5f);
    }

    private void TurnOffCanvas()
    {
        _fadeUI.SetActive(false);
    }



}
