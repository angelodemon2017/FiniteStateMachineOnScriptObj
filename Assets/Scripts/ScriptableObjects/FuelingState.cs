using UnityEngine;

[CreateAssetMenu]
public class FuelingState : State
{
    [SerializeField] private Transform transformFuelStation;

    public override void Init()
    {
        if (transformFuelStation == null)
            transformFuelStation = character.transformFuelStation;

        IsFinished = false;
    }

    public override void Run()
    {
        if (IsFinished) return;

        FuelingOfMoveToStation();

        if (character.Fuel > 20f)
        {
            IsFinished = true;
            character.isFueling = false;
        }
    }

    void FuelingOfMoveToStation() 
    {
        if (!character.isFueling)
        {
            character.transform.Translate((transformFuelStation.position - character.transform.position).normalized * speed);
        }

        if (Vector3.Distance(transformFuelStation.position, character.transform.position) < check_distance)
        {
            character.isFueling = true;
            character.Fuel += Time.deltaTime*4;
        }
    }
}