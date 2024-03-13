using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeState { Comer,Jugar,Banno,Dormir}
public class State : MonoBehaviour
{
    public TypeState type;
    public Energy _energy;
    public MachineState m_MachineState;
    public virtual void LoadComponent()
    {
        _energy = GetComponent<Energy>();
        m_MachineState = GetComponent<MachineState>();
    }
    public virtual void Enter( )
    {

    }
    public virtual void Execute()
    {
      
    }
    public virtual void Exit()
    {

    }
}
