using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomInfo
{
    [SerializeField] private RoomType _roomType;
    [SerializeField] private Room _room;

    [SerializeField] private Material _skyboxMaterial;
    [SerializeField] private Texture[] _switchRoomTextures;

    [SerializeField] private AudioClip _audioBackground;
    [SerializeField] private AudioSource _speakerAudioSource;
    [SerializeField] private AudioClip[] _speakerClips;


    private int _welcomeCounter;
   

    public RoomType RoomType => _roomType;
    public Room Room => _room;
    public Material SkyboxMaterial => _skyboxMaterial;
    public Texture[] SwitchRoomTextures => _switchRoomTextures;
    public AudioClip AudioBackground => _audioBackground;
    public AudioSource SpeakerAudioSource => _speakerAudioSource;
    public AudioClip[] SpeakerClips => _speakerClips;
    public int WelcomeCounter { get; set; }

}
