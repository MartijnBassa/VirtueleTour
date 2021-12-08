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
                // deactivate current room
                if(_currentActiveRoomInfo != null)
                {
                    _currentActiveRoomInfo.Room.gameObject.SetActive(false);
                }

                // check if next room has skybox info, set skybox to 360 video
                if(roomInfo.Material != null)
                {
                    RenderSettings.skybox = roomInfo.Material;
                }
                else
                {
                    RenderSettings.skybox = null;
                }

                // check if next room has background audio info, set audiosource clip to background sound
                if(roomInfo.AudioBackground != null)
                {
                    roomInfo.Room.gameObject.GetComponentInChildren<AudioSource>().clip = roomInfo.AudioBackground;
                }

                // check if next room has a person speaking, set clip to first welcome if first time entering else second welcome
                if(roomInfo.SpeakerAudioSource != null)
                {
                    if (roomInfo.WelcomeCounter <= 0)
                    {
                        roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[roomInfo.WelcomeCounter];
                        CountWelcomes(roomInfo);
                    }
                    else
                    {
                        roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[roomInfo.WelcomeCounter];
                    }

                }

                // activate next room
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

    private void CountWelcomes(RoomInfo roomInfo)
    {
        roomInfo.WelcomeCounter++;

        if(roomInfo.WelcomeCounter >= 1)
        {
            roomInfo.WelcomeCounter = 1;
        }
    }
}
