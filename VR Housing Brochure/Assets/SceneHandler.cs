/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private SteamVR_LaserPointer _laserPointerLeft;
    [SerializeField] private SteamVR_LaserPointer _laserPointerRight;

    void Awake()
    {
        _laserPointerLeft.PointerClick += PointerClick;
        _laserPointerRight.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        e.target.gameObject.GetComponent<Button>().onClick.Invoke();
        

    }
}