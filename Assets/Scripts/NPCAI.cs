using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    private Animator _animator;
    public Transform transformBasaOil;
    public Transform transformTrushStorage;
    [SerializeField] private float fuel = 20f;
    [SerializeField] private bool parkingOnRefuel;
    [SerializeField] private int trushPackets = 0;

    [SerializeField] public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        parkingOnRefuel = Vector3.Distance(transform.position, transformBasaOil.position) < 1f;
        if (parkingOnRefuel)
        {
            fuel += Time.deltaTime * 4;
        }
        else
        {
            fuel -= Time.deltaTime;
        }
        _animator.SetFloat("fuel", fuel);
        _animator.SetBool("parkingOnRefuel", parkingOnRefuel);
    }

    public void resetTrush()
    {
        trushPackets = 0;
        _animator.SetInteger("trushPackets", trushPackets);
    }

    public void trushAdding(int countPack) 
    {
        trushPackets += countPack;
        _animator.SetInteger("trushPackets", trushPackets);
    }
}
