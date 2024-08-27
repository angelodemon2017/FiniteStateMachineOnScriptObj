using System.Collections.Generic;
using UnityEngine;

public class SSOController : MonoBehaviour, IStatesCharacter, IAnimated
{
    [SerializeField] private List<State> _triggeredStates = new();

    private State _currentState;

    private void Awake()
    {
        SetState(_triggeredStates[0]);
    }

    private void Update()
    {
        foreach (var tempState in _triggeredStates)
        {
            if (tempState.GeneralTrigger)
            {
                SetState(tempState);
            }
        }

        _currentState.Run();
    }

    public void PlayAnimation(Animates idAnim)
    {

    }

    public void SetState(State state)
    {
        _currentState = Instantiate(state);
        _currentState.Character = this;
        _currentState.Init();
    }
}