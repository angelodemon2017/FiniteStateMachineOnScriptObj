using UnityEngine;

[CreateAssetMenu]
public class IdleState : State
{
    public override void Init()
    {
        IsFinished = false;
        ((IAnimated)Character).PlayAnimation(0);
    }

    public override void Run()
    {
        if (IsFinished)
        {
            if (NextState != null)
            {
                Character.SetState(NextState);
            }

            return;
        }

        //Idle timer for example
    }
}