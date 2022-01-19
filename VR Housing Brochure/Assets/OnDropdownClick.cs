using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnDropdownClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Dropdown _dropDown;

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("Test");
    }
}
