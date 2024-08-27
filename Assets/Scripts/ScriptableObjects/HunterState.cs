using UnityEngine;

[CreateAssetMenu]
public class HunterState : State
{
    public override bool GeneralTrigger => base.GeneralTrigger;//Если учуял игрока

    public override void Init()
    {
        IsFinished = false;
    }

    public override void Run()
    {
        if (IsFinished) return;

    }
}