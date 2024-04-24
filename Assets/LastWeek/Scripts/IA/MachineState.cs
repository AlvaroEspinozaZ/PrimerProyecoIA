using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineState : MonoBehaviour
{
  
    public State CurrentState;
    public State []m_States;
    public TypeState stateDefaul;
    public TypePath nextpath;

    private void Start()
    {
       
          m_States = GetComponents<State>();
        foreach (var item in m_States)
        {
            if (item.type == stateDefaul)
            {
                    item.Enter();

                    item.enabled = true;

                    CurrentState = item;
                    
            }
            else
            {
                item.enabled = false;
            }

        }
    }
    public void NextState(TypeState state)
    {
        foreach (var item in m_States)
        {
            if(item.type == state)
            {
                if (CurrentState != null)
                {
                    CurrentState.Exit();
                    CurrentState.enabled = false;

                    CurrentState = item;
                    CurrentState.enabled=true;
                    CurrentState.Enter();
                }                   
            }            
        }
    }

    public void NextState(TypeState state,TypePath path)
    {
        //Debug.Log("Estoy entrando al NExSTATE");
        foreach (var item in m_States)
        {
            //Debug.Log("Estoy ubicando el state "+ state);
            if (item.type == state)
            {
                //Debug.Log("Encontre " + state);
                if (CurrentState != null)
                {
                    CurrentState.Exit();
                    CurrentState.enabled = false;
                    //Debug.Log("Apago " + CurrentState);
                    CurrentState = item;
                    CurrentState.enabled = true;
                    CurrentState.Enter();
                }
            }
            nextpath = path;
        }
    }
    public void DesactiveStateAll()
    {
        foreach (var item in m_States)
        {
            item.enabled = false;
        }
    }
}
