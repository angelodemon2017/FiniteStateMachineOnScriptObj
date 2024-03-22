using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCState
{
    patrol,
    fueling,
    trushDropping,
}

public class NPC_FSM_Controller : MonoBehaviour
{
    [SerializeField] private Transform transformBasaOil;
    private bool isFueling = false;
    [SerializeField] private float fuel = 20f;

    [SerializeField] private Transform transformTrushStorage;
    private int trushPackets = 0;

    [SerializeField] private List<Transform> targets = new List<Transform>();
    private int currentTarget = 0;

    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float check_distance = 0.5f;

    private NPCState currentState = NPCState.patrol;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case NPCState.patrol:
                Patrolling();
                if (fuel < 5f)
                {
                    currentState = NPCState.fueling;
                }
                if (trushPackets > 10)
                {
                    currentState = NPCState.trushDropping;
                }
                break;
            case NPCState.fueling:
                Fueling();
                if (fuel > 20f)
                {
                    currentState = NPCState.patrol;
                    isFueling = false;
                }
                break;
            case NPCState.trushDropping:
                if (fuel < 5f)
                {
                    currentState = NPCState.fueling;
                }
                if (trushPackets == 0) 
                {
                    currentState = NPCState.patrol;
                }
                TrushDropping();
                break;
        }
        if(!isFueling)
        {
            fuel -= Time.deltaTime;
        }
    }

    void Patrolling()
    {
        transform.Translate((targets[currentTarget].position - transform.position).normalized * speed);

        if (Vector3.Distance(targets[currentTarget].position, transform.position) < check_distance)
        {
            currentTarget++;
            trushPackets += 2;
            if (currentTarget >= targets.Count)
            {
                currentTarget = 0;
            }
        }
    }

    void Fueling()
    {
        isFueling = Vector3.Distance(transform.position, transformBasaOil.position) < check_distance;
        if (isFueling)
        {
            fuel += Time.deltaTime * 4;
        }
        else
        {
            transform.Translate((transformBasaOil.position - transform.position).normalized * speed);
        }
    }

    void TrushDropping()
    {
        transform.Translate((transformTrushStorage.position - transform.position).normalized * speed);
        if (Vector3.Distance(transformTrushStorage.position, transform.position) < check_distance)
        {
            trushPackets = 0;
        }
    }
}