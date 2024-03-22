using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    [SerializeField] private List<Transform> targets = new List<Transform>();
    [SerializeField] private float check_distance = 0.1f;
    private int currentTarget;
    private bool isPatrol = true;

    [SerializeField] private float speed = 0.1f;

    void Update()
    {
        if (isPatrol) 
        {
            Moving();
        }
    }

    private void Moving() 
    {
        transform.Translate((targets[currentTarget].position - transform.position).normalized * speed);
        if (Vector3.Distance(targets[currentTarget].position, transform.position) < check_distance)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        currentTarget++;
        if (currentTarget == targets.Count)
        {
            currentTarget = 0;
        }
    }
}
