using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomInfo
{
    [SerializeField] private RoomType _roomType;
    [SerializeField] private Room _room;
    [SerializeField] private Material _material;
    [SerializeField] private AudioClip _audioClip;

    public RoomType RoomType => _roomType;
    public Room Room => _room;
    public Material Material => _material;
    public AudioClip AudioClip => _audioClip;

}
