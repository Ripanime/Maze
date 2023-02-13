using UnityEngine;
using Player;
public interface IPositionAdapter 
{
    Vector3 Position { get; set; }
}
public class PlayerControllerMove : MonoBehaviour,IPositionAdapter
{
    [SerializeField] private PlayerControllerData playerControllerData;
    [SerializeField] private Joystick joystick;
    [SerializeField] private LayerMask colliderMask;
    [SerializeField] private Transform movePoint;
    private PlayerMove playerMove;
    private Vector3 pointToMove;
    public Vector3 Position 
    {
        get 
        {
            return transform.position;
        }
        set 
        {
            transform.position = value;
        }
    }
    private void Awake()
    {
        playerMove = new PlayerMove(colliderMask, playerControllerData);
    }
    private void Start()
    {
        movePoint.parent = null;
    }
    void Update()
    {
        transform.position = playerMove.Move(this.Position,movePoint.position,Time.deltaTime,joystick.Horizontal,joystick.Vertical);
        if (playerMove.IsDrug) 
        {
            pointToMove = playerMove.PositionToMove;
            movePoint.position = playerMove.MovePointMove(movePoint.position, pointToMove);
        }
    }
    private void OnDrawGizmosSelected()
    {
        playerMove.DrawGizmos(movePoint.position, joystick.Horizontal);
    }
}
