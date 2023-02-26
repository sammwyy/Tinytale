using UnityEngine;

public enum EntityDirection
{
    DOWN = 0, LEFT = 1, UP = 2, RIGHT = 3
}

static class EntityDirectionMethods
{

    public static Vector3 ToVector3D(this EntityDirection direction)
    {
        switch (direction)
        {
            case EntityDirection.DOWN:
                return Vector3.down;
            case EntityDirection.LEFT:
                return Vector3.left;
            case EntityDirection.UP:
                return Vector3.up;
            case EntityDirection.RIGHT:
                return Vector3.right;
            default:
                return Vector3.down;
        }
    }

    public static Vector2 ToVector2D(this EntityDirection direction)
    {
        switch (direction)
        {
            case EntityDirection.DOWN:
                return Vector2.down;
            case EntityDirection.LEFT:
                return Vector2.left;
            case EntityDirection.UP:
                return Vector2.up;
            case EntityDirection.RIGHT:
                return Vector2.right;
            default:
                return Vector2.down;
        }
    }
}
