using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugar : State
{
    float FrameRate;
    int id = 0;
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
        _myBehaviursIA.Point = _myPaths.GetPaths(_myPaths.datapaths[0].type)[0];        
       

    }
    public override void Execute()
    {
        if (id < _myPaths.GetPaths(_myPaths.datapaths[0].type).Length - 1)
        {
            float distanceToCurrent = Vector3.Distance(transform.position, _myPaths.GetPaths(_myPaths.datapaths[0].type)[id].position);
            Debug.Log(distanceToCurrent);
            if (distanceToCurrent < 0.5f)
            {
                id++;
                _myBehaviursIA.Point = _myPaths.GetPaths(_myPaths.datapaths[0].type)[id];
            }
        }


        if (id>= _myPaths.GetPaths(_myPaths.datapaths[0].type).Length - 1)
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
                    m_MachineState.NextState(TypeState.Dormir);
                _energy.hungry = Mathf.Clamp(_energy.hungry - UnityEngine.Random.Range(6, 16), 0, 100);
                if (_energy.hungry == 0)
                    m_MachineState.NextState(TypeState.Comer);

                if (_energy.WC == 100)
                    m_MachineState.NextState(TypeState.Banno);
                //return;
            }
            FrameRate += Time.deltaTime;
        }
       
    }

    void Update()
    {
        Execute();
    }

}
