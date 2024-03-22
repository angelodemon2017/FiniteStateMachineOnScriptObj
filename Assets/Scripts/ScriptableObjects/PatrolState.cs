using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class PatrolState : State
{
    [SerializeField] private List<Transform> targets = new List<Transform>();
    private int currentTarget = 0;

    public override void Init()
    {
        if (targets.Count == 0) 
        {
            targets = GameObject.FindGameObjectsWithTag("point").Select(x => x.transform).ToList();
        }
        IsFinished = false;
    }

    public override void Run()
    {
        if (IsFinished) return;

        PatrolPoints();

        if (character.Fuel < 5f || character.TrushPacket > 10) 
        {
            IsFinished = true;
        }
    }

    void PatrolPoints() 
    {
        character.transform.Translate((targets[currentTarget].position - character.transform.position).normalized * speed);

        if (Vector3.Distance(targets[currentTarget].position, character.transform.position) < check_distance)
        {
            currentTarget++;
            character.TrushPacket += 2;
            if (currentTarget >= targets.Count)
            {
                currentTarget = 0;
            }
        }
    }
}