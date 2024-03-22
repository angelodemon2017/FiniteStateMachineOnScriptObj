using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class TrushDropingState : State
{
    [SerializeField] private Transform transformTrushDropPlace;

    public override void Init()
    {
        if (transformTrushDropPlace == null)
            transformTrushDropPlace = character.transformTrushDropPlace;

        IsFinished = false;
    }

    public override void Run()
    {
        if (IsFinished) return;

        MoveToTrushDrop();

        if (character.TrushPacket == 0 || character.Fuel < 5f)
        {
            IsFinished = true;
        }
    }

    void MoveToTrushDrop() 
    {
        character.transform.Translate((transformTrushDropPlace.position - character.transform.position).normalized * speed);

        if (Vector3.Distance(transformTrushDropPlace.position, character.transform.position) < check_distance)
        {
            character.TrushPacket = 0;
        }
    }
}