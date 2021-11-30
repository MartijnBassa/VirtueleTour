using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Room1,
    Room2,
    Room3,
    Room4
}


public class RoomManager : Singleton<RoomManager>
{
    [SerializeField] private RoomInfo[] _roomInfos;
    [SerializeField] private RoomType _startRoomType;

    private RoomInfo _currentActiveRoomInfo;

    private void Start()
    {
        DeactivateAllRooms();
        SwitchRoom(_startRoomType);
    }

    public void SwitchRoom(RoomType roomType)
    {
        foreach (RoomInfo roomInfo in _roomInfos)
        {
            if(roomType == roomInfo.RoomType)
            {
                if(_currentActiveRoomInfo != null)
                {
                    _currentActiveRoomInfo.Room.gameObject.SetActive(false);
                }

                roomInfo.Room.gameObject.SetActive(true);

                _currentActiveRoomInfo = roomInfo;
            }
        }
    }

    private void DeactivateAllRooms()
    {
        foreach (RoomInfo roomInfo in _roomInfos)
        {
            roomInfo.Room.gameObject.SetActive(false);
        }
    }
}
