using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomInfo
{
    [SerializeField] private RoomType _roomType;
    [SerializeField] private Room _room;

    public RoomType RoomType => _roomType;
    public Room Room => _room;

}
