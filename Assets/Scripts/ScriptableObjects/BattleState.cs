using UnityEngine;

[CreateAssetMenu]
public class BattleState : State
{
    public override bool GeneralTrigger => base.GeneralTrigger;//Если игрок в зоне досягаемости

    public override void Init()
    {
        IsFinished = false;
    }

    public override void Run()
    {
        if (IsFinished) return;

    }
}