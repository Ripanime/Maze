using UnityEngine;

namespace Player 
{
    internal interface IMovable 
    {
        Vector3 Move(Vector3 position, Vector3 movePointPosition, float timeToRestart, float joystickHorizontal, float joystickVertical);
        void DrawGizmos(Vector3 movePointPosition, float joystickHorizontal);
        Vector3 MovePointMove(Vector3 position, Vector3 positionToMove);
    }
    public class PlayerMove : IMovable
    {
        public bool IsDrug { get; private set; }
        public Vector3 PositionToMove { get; private set; }

        readonly LayerMask colliderMask;
        readonly PlayerControllerData controllerData;
        private float valueScaleHorizontal;
        private float valueScaleVertical;
        public PlayerMove(LayerMask colliderMask,PlayerControllerData controllerData) 
        {
            this.colliderMask = colliderMask;
            this.controllerData = controllerData;
        }
        public Vector3 Move(Vector3 position,Vector3 movePointPosition,float timeToRestart, float joystickHorizontal,float joystickVertical) 
        {
            position = Vector3.MoveTowards(position, movePointPosition, controllerData.MoveSpeed * timeToRestart);
            IsDrug = false;
            if (Vector3.Distance(position, movePointPosition) <= controllerData.Distance)
            {
                if (Mathf.Abs(joystickHorizontal) >= controllerData.JoystickMove)
                {
                    valueScaleHorizontal = controllerData.OneGridMoveHorizontal / Mathf.Abs(joystickHorizontal);
                    if (!Physics2D.OverlapCircle(movePointPosition + new Vector3(joystickHorizontal / Mathf.Abs(joystickHorizontal) * controllerData.PhysicsScaler, 0f, 0f), controllerData.PhysicsCircle, colliderMask))
                    {
                        IsDrug = true;
                        PositionToMove = new Vector3(joystickHorizontal * valueScaleHorizontal, 0f, 0f);
                    }
                }

                if (Mathf.Abs(joystickVertical) >= controllerData.JoystickMove)
                {
                    valueScaleVertical = controllerData.OneGridMoveVertical / Mathf.Abs(joystickVertical);
                    if (!Physics2D.OverlapCircle(movePointPosition + new Vector3(0f, joystickVertical / Mathf.Abs(joystickVertical) * controllerData.PhysicsScaler, 0f), controllerData.PhysicsCircle, colliderMask))
                    {
                        IsDrug = true;
                        PositionToMove = new Vector3(0f, joystickVertical * valueScaleVertical, 0f);
                    }
                }
            }
            return position;
        }
        public Vector3 MovePointMove(Vector3 position, Vector3 positionToMove) 
        {
            position += positionToMove;
            return position;
        }
        public void DrawGizmos(Vector3 movePointPosition,float joystickHorizontal) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(movePointPosition + new Vector3(joystickHorizontal / Mathf.Abs(joystickHorizontal) * controllerData.PhysicsScaler, 0f, 0f), controllerData.PhysicsCircle);
        }
    }
}
