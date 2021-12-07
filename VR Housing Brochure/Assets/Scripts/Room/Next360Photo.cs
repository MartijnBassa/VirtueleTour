using UnityEngine;

public class Next360Photo : MonoBehaviour
{
    [SerializeField] private RoomType _roomType;

    //[SerializeField] private Material _equirectangularPhotoMaterial;
    //[SerializeField] private GameObject _equirectangularPhotoSphere;
    //[SerializeField] private Texture _equirectangularPhotoTexture;
    [SerializeField] private GameObject _fadeUI;

    //[SerializeField] private Room _currentRoom;
    //[SerializeField] private Direction _direction;

    private const string _animationOn = "FadeInAnimation";
    private const string _animationOff = "FadeOutAnimation";



    // Change spheres texture to new texture
    public void NextPhoto()
    {
        // SetDirection based on enum of button
        //_currentRoom.SetDirection(_direction);
        // Sets previousdirection (button to previous room) based off enum
        //SetLookingDirection();

        CanvasAnimation(_animationOn, false);
        //_equirectangularPhotoSphere.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", _equirectangularPhotoTexture);
        RoomManager.Get.SwitchRoom(_roomType);
        CanvasAnimation(_animationOff, true);
        
    }

    /*    private void SetLookingDirection()
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

        }*/

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
