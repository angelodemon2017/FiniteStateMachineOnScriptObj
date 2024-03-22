using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    [HideInInspector] public NPC_State_Controller character;
    [SerializeField] protected float speed = 0.05f;
    [SerializeField] protected float check_distance = 0.5f;

    public virtual void Init() { }

    public abstract void Run();
}
