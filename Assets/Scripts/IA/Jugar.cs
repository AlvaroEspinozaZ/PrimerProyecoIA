using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : State
{
    float FrameRate;

    [SerializeField] float[] arrayTime = new float[10];
    [SerializeField] int index = 0;
    void Start()
    {
        RandeArray();
        LoadComponent();
    }
    void RandeArray()
    {
        for (int i = 0; i < arrayTime.Length; i++)
        {
            arrayTime[i] = UnityEngine.Random.Range(1, 4);
        }
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    // Update is called once per frame

    public override void Enter()
    {
        Debug.Log("Estoy jugando");
        FrameRate = 0;        
        _myBehaviursIA.Point = _myPaths.GetPaths(TypePath.Jugar)[0];
        
    }
    public override void Execute()
    {
        if (FrameRate > arrayTime[index])
        {
            FrameRate = 0;
            index++;
        if (index == arrayTime.Length)
            {
            RandeArray();
            index = index % arrayTime.Length;
            }
            _energy.energy = Mathf.Clamp(_energy.energy - UnityEngine.Random.Range(6, 16), 0, 100);
            if (_energy.energy == 0)
            {
                Debug.Log("Deberia moverme a Dormir");
                m_MachineState.NextState(TypeState.Moverse, TypePath.Dormir);
                //m_MachineState.NextState(TypeState.Dormir);
            }

            _energy.hungry = Mathf.Clamp(_energy.hungry - UnityEngine.Random.Range(6, 16), 0, 100);
                if (_energy.hungry == 0)
            {
                Debug.Log("Deberia moverme a Comer");
                m_MachineState.NextState(TypeState.Moverse, TypePath.Comer);
                //m_MachineState.NextState(TypeState.Comer);
            }


            if (_energy.WC == 100)
            {
                Debug.Log("Deberia moverme a Banno");
                m_MachineState.NextState(TypeState.Moverse, TypePath.Banno);
                //m_MachineState.NextState(TypeState.Banno);
                //return;
            }
        }
            FrameRate += Time.deltaTime;
    }

    void Update()
    {
        Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Juguete")
        {
            other.gameObject.SetActive(false);
        }
    }
}
