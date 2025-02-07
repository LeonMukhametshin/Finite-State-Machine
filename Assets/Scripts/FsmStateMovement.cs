using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected readonly Transform Transform;
    protected readonly float Speed;

    public FsmStateMovement(Fsm fsm, Transform transform, float speed) : base(fsm)
    {
        Transform = transform;
        Speed = speed;
    }

    public override void Enter()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [EXIt]");
    }

    public override void Update()
    {
        Debug.Log($"Movement ({this.GetType().Name}) state [UPDATE] with speed: {Speed}");

        var inputDirection = ReadInput();

        if(inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        Move(inputDirection);
    }

    protected virtual Vector2 ReadInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return input;
    }

    protected virtual void Move(Vector2 inputDirection)
    {
        Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
    }
}

