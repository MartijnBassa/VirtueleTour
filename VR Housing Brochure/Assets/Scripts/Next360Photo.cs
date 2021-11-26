using UnityEngine;

public class Next360Photo : MonoBehaviour
{
    // Instead of changing the texture, changing the whole object may be necessary. 
    // The buttons that contain the photos will remain the same throughout pictures. Resulting in the photos not linking up.
    // If you go from one room to another, the buttons will have the photos from the previous room which makes no sense.

    //[SerializeField] private Material _equirectangularPhotoMaterial;
    [SerializeField] private GameObject _equirectangularPhotoSphere;
    [SerializeField] private Texture _equirectangularPhotoTexture;
    [SerializeField] private GameObject _fadeUI;

    [SerializeField] private GameObject _player;
    [SerializeField] private Room _currentRoom;
    [SerializeField] private Direction _direction;

    private const string _animationOn = "FadeInAnimation";
    private const string _animationOff = "FadeOutAnimation";

    // Change spheres texture to new texture
    public void NextPhoto()
    {

        // SetDirection based on enum of button
        _currentRoom.SetDirection(_direction);
        // Sets previousdirection (button to previous room) based off enum
        SetLookingDirection();

        //CanvasAnimation(_animationOn, false);
        _equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTexture);
        //CanvasAnimation(_animationOff, true);
        // Calculate angle from cameraholder to pressed button
    }

    private void SetLookingDirection()
    {
        switch (_currentRoom.GetDirection())
        {
            case Direction.North:
                _currentRoom.SetPreviousDirection(Direction.South);
                break;

            case Direction.South:
                _currentRoom.SetPreviousDirection(Direction.North);
                break;

            case Direction.East:
                _currentRoom.SetPreviousDirection(Direction.West);
                break;

            case Direction.West:
                _currentRoom.SetPreviousDirection(Direction.East);
                break;

            default:
                break;
        }

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
