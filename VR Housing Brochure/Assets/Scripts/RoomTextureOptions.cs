using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomTextureOptions : MonoBehaviour
{
    [SerializeField] Dropdown _dropdown;

    private RoomManager _roomManager;
    private List<string> _dropdownOptions;

    private void Awake()
    {
        _dropdownOptions = new List<string>();
        _roomManager = RoomManager.Get;
    }

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(delegate
        {
            SetRoomTexture(_dropdown);
        });

        // on start create same amount of dropdown options as photos in roomInfo
        if (_roomManager.NumberOfImages > 0)
        {
            for (int i = 1; i < _roomManager.NumberOfImages + 1; i++)
            {
                _dropdownOptions.Add("Option " + i);
            }

            _dropdown.AddOptions(_dropdownOptions);
        }
    }

    public void SetRoomTexture(Dropdown dropdown)
    {
        RoomManager.Get.SwitchRoomTexture(dropdown.value);
    }

}
