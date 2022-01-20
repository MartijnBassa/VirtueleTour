using UnityEngine;

public enum RoomType
{
    Room1,
    Room2,
    Room3,
    Room4,
    Room5,
    Room6,
    Room7,
    Room8
}


public class RoomManager : Singleton<RoomManager>
{
    [SerializeField] private RoomInfo[] _roomInfos;
    [SerializeField] private RoomType _startRoomType;

    private RoomInfo _currentActiveRoomInfo;

    private int _numberOfImages;
    private float _welcomeTimer;
    private float _timeToWelcome = 60f;

    public int NumberOfImages => _numberOfImages;
    public RoomInfo CurrentActiveRoomInfo => _currentActiveRoomInfo;

    private void Awake()
    {
        DeactivateAllRooms();
        SwitchRoom(_startRoomType);

        _numberOfImages = _currentActiveRoomInfo.SwitchRoomTextures.Length;

    }

    private void Update()
    {
        _welcomeTimer += Time.deltaTime;

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

                SetSkybox(roomInfo);
                AudioBackground(roomInfo);
                AudioWelcome(roomInfo);


                // activate next room
                roomInfo.Room.gameObject.SetActive(true);

                _currentActiveRoomInfo = roomInfo;

            }
        }
    }

    public void SwitchRoomTexture(int index)
    {
        foreach (RoomInfo roomInfo in _roomInfos)
        {
            if(roomInfo.RoomType == _currentActiveRoomInfo.RoomType)
            {
                roomInfo.Room.gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", roomInfo.SwitchRoomTextures[index]);
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

    private void AudioWelcome(RoomInfo roomInfo)
    {
        // check if next room has a person speaking, set clip to first welcome if first time entering else second welcome
        if (roomInfo.SpeakerAudioSource != null)
        {
            if (roomInfo.WelcomeCounter == 0)
            {
                roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[roomInfo.WelcomeCounter];
                CountWelcomes(roomInfo);
            }
            else if(roomInfo.WelcomeCounter == 1)
            {
                roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[roomInfo.WelcomeCounter];
                CountWelcomes(roomInfo);

            }
            else
            {
                roomInfo.SpeakerAudioSource.clip = null;

                if (_welcomeTimer >= _timeToWelcome)
                {
                    roomInfo.SpeakerAudioSource.clip = roomInfo.SpeakerClips[1];
                    _welcomeTimer = 0f;
                }
            }
        }
    }

    private void AudioBackground(RoomInfo roomInfo)
    {
        // check if next room has background audio info, set audiosource clip to background sound
        if (roomInfo.AudioBackground != null)
        {
            roomInfo.Room.gameObject.GetComponentInChildren<AudioSource>().clip = roomInfo.AudioBackground;
        }
    }

    private void SetSkybox(RoomInfo roomInfo)
    {
        // check if next room has skybox info, set skybox to 360 video
        if (roomInfo.SkyboxMaterial != null)
        {
            RenderSettings.skybox = roomInfo.SkyboxMaterial;
        }
        else
        {
            RenderSettings.skybox = null;
        }
    }

    private void CountWelcomes(RoomInfo roomInfo)
    {
        roomInfo.WelcomeCounter++;
    }
}
