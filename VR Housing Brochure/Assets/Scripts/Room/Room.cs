using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class Room : MonoBehaviour
{
    private List<Room> _rooms;

    protected Direction _direction;
    protected Direction _previousDirection;
    protected int _roomId;
    protected int _previousRoomId;
    protected int _currentRoomId;
    protected Texture _sphereTexture;


}
