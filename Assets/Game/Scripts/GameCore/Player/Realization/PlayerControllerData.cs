using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new PlayerControllerData", menuName = "PlayerControllerData",order = 52)]
public class PlayerControllerData : ScriptableObject
{
    public float MoveSpeed;

    [SerializeField] private float distance = 0.5f;
    public float Distance => distance;

    [SerializeField] private float oneGridMoveHorizontal;
    public float OneGridMoveHorizontal => oneGridMoveHorizontal;

    [SerializeField] private float oneGridMoveVertical;
    public float OneGridMoveVertical => oneGridMoveVertical;

    [SerializeField] private float physicsCircle = 0.2f;
    public float PhysicsCircle => physicsCircle;

    [SerializeField] private float physicsScaler;
    public float PhysicsScaler => physicsCircle;

    [SerializeField, Range(0, 1)] private float joystickMove;
    public float JoystickMove => joystickMove;

    [SerializeField] private string checkTag;
    public string CheckTag => checkTag;
}