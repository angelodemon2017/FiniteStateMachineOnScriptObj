using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_State_Controller : MonoBehaviour
{
    public int TrushPacket = 0;
    public float Fuel = 10f;
    public bool isFueling = false;

    public Transform transformFuelStation;
    public Transform transformTrushDropPlace;

    public State PatrolState;
    public State FuelingState;
    public State TrushDropState;

    private State currentSate;

    // Start is called before the first frame update
    void Start()
    {
        SetState(PatrolState);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFueling) 
        {
            Fuel -= Time.deltaTime;
        }

        if (!currentSate.IsFinished)
        {
            currentSate.Run();
        }
        else 
        {
            if (Fuel < 5f)
            {
                SetState(FuelingState);
            }
            else if (TrushPacket > 10)
            {
                SetState(TrushDropState);
            }
            else 
            {
                SetState(PatrolState);
            }
        }
    }

    private void SetState(State state) 
    {
        currentSate = Instantiate(state);
        currentSate.character = this;
        currentSate.Init();
    }
}