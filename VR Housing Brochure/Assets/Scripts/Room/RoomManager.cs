using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Room1,
    Room2,
    Room3,
    Room4,
    Room5
}


public class RoomManager : Singleton<RoomManager>
{
    [SerializeField] private RoomInfo[] _roomInfos;
    [SerializeField] private RoomType _startRoomType;

    private RoomInfo _currentActiveRoomInfo;
    private int welcomeCounter;

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

                if(roomInfo.Material != null)
                {
                    RenderSettings.skybox = roomInfo.Material;
                }
                else
                {
                    RenderSettings.skybox = null;
                }

                if(roomInfo.AudioBackground != null)
                {
                    roomInfo.Room.gameObject.GetComponentInChildren<AudioSource>().clip = roomInfo.AudioBackground;
                }

                if(roomInfo.SpeakerAudioSource != null)
                {
                    if (welcomeCounter <= 0)
                    {
                        roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[welcomeCounter];
                        CountWelcomes();
                    }
                    else
                    {
                        roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[welcomeCounter];
                    }

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

    private void CountWelcomes()
    {
        welcomeCounter++;

        if(welcomeCounter >= 1)
        {
            welcomeCounter = 1;
        }
    }
}
