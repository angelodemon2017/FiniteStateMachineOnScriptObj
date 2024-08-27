using UnityEngine;

[CreateAssetMenu]
public class WalkingState : State
{
    public override void Init()
    {
        IsFinished = false;
        ((IAnimated)Character).PlayAnimation(0);
    }

    public override void Run()
    {
        if (IsFinished) return;
    }
}