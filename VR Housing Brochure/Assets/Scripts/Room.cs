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

    public Room()
    {

    }

    public void SetPreviousDirection(Direction direction)
    {
;
        _previousDirection = direction;
    }

    public void SetDirection(Direction direction)
    {

        _direction = direction;
    }

    public Direction GetDirection()
    {
        return _direction;
    }

    public Direction GetPreviousDirection()
    {
        return _previousDirection;
    }

}
