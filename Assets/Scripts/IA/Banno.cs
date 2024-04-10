using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banno : State
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
    void Update()
    {
        Execute();
    }
    public override void Enter()
    {
        Debug.Log("Estoy Baño");
        FrameRate = 0;
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
            
            _energy.WC = Mathf.Clamp(_energy.WC - UnityEngine.Random.Range(5, 16), 0, 100);
            if (_energy.WC == 0)
                m_MachineState.NextState(TypeState.Moverse, TypePath.Jugar);

        }
        FrameRate += Time.deltaTime;
    }
}
