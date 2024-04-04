using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverse : State
{
    float FrameRate;
    [SerializeField] float[] arrayTime = new float[10];
    [SerializeField] int index = 0;
    int id = 0;
   
    void Start()
    {
        RandeArray();
        LoadComponent();
        _mypath.type = m_MachineState.nextpath;
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
    void Update()
    {
        Execute();
    }
    public override void Enter()
    {
        Debug.Log("Estoy Moviendome");
        FrameRate = 0;
        _myBehaviursIA.Point = _myPaths.GetPaths(m_MachineState.nextpath)[0];
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
            if (id < _myPaths.GetPaths(m_MachineState.nextpath).Length - 1)
            {
                float distanceToCurrent = Vector3.Distance(transform.position, _myPaths.GetPaths(m_MachineState.nextpath)[id].position);
                
                Debug.Log(distanceToCurrent);
                if (distanceToCurrent < 0.5f)
                {
                    id++;
                    _myBehaviursIA.Point = _myPaths.GetPaths(m_MachineState.nextpath)[id];
                }
            }
            float lastDistanceToCurrent = Vector3.Distance(transform.position, _myPaths.GetPaths(m_MachineState.nextpath)[_myPaths.GetPaths(m_MachineState.nextpath).Length - 1].position);
            if (lastDistanceToCurrent < 0.5f)
            {
                switch (m_MachineState.nextpath)
                {
                    case TypePath.Comer:
                        m_MachineState.NextState(TypeState.Comer);
                        break;
                    case TypePath.Dormir:
                        m_MachineState.NextState(TypeState.Dormir);
                        break;
                    case TypePath.Jugar:
                        m_MachineState.NextState(TypeState.Jugar);
                        break;
                    case TypePath.Banno:
                        m_MachineState.NextState(TypeState.Banno);
                        break;
                }
            }            
        }
            FrameRate += Time.deltaTime;
    }
}
