using UnityEngine;

public class Next360Photo : MonoBehaviour
{

    //[SerializeField] private Material _equirectangularPhotoMaterial;
    [SerializeField] private GameObject _equirectangularPhotoSphere;
    [SerializeField] private Texture _equirectangularPhotoTexture;
    [SerializeField] private GameObject _fadeUI;

    private const string _animationOn = "FadeInAnimation";
    private const string _animationOff = "FadeOutAnimation";

    // Change spheres texture to new texture
    public void NextPhoto()
    {
        //CanvasAnimation(_animationOn, false);
        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTexture);
        //CanvasAnimation(_animationOff, true);

    }

    private void CanvasAnimation(string text, bool fadeOut)
    {
        _fadeUI.SetActive(true);
        _fadeUI.GetComponent<Animation>().Play(text);

        if(fadeOut)
            Invoke(nameof(TurnOffCanvas), 1.5f);
    }

    private void TurnOffCanvas()
    {
        _fadeUI.SetActive(false);
    }



}
