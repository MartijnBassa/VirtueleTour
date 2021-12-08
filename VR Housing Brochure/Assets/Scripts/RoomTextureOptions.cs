using UnityEngine;
using UnityEngine.UI;

public class RoomTextureOptions : MonoBehaviour
{
    [SerializeField] Dropdown _dropdown;

    private int _dropdownValue;

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(delegate
        {
            SetRoomTexture(_dropdown);
        });
    }

    public void SetRoomTexture(Dropdown dropdown)
    {
        RoomManager.Get.SwitchRoomTexture(dropdown.value);
    }
}
