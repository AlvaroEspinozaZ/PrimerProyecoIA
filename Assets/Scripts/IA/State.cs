using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeState { Comer,Jugar,Banno,Dormir,Moverse}
public class State : MonoBehaviour
{
    public TypeState type;
    public Energy _energy;
    public MachineState m_MachineState;
    public PathFollowing _myPaths;
    public BehaviursIA _myBehaviursIA;
    public PathFollowing _mypath;
    public virtual void LoadComponent()
    {
        _energy = GetComponent<Energy>();
        m_MachineState = GetComponent<MachineState>();
        _myPaths = GetComponent<PathFollowing>();
        _myBehaviursIA = GetComponent<BehaviursIA>();
        _mypath = GetComponent<PathFollowing>();
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
