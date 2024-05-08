using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionGetToy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (_AICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchMoveToToy();
        return TaskStatus.Success;

    }

    void SwitchMoveToToy()
    {
        switch (Unit)
        {
            case TypeUnit.Soldier:
                if (_AICharacterVehicle is AICharacterVehicleSoldier)
                {
                    ((AICharacterVehicleSoldier)_AICharacterVehicle).MoveToObject();
                }
                break;
            case TypeUnit.None:
                break;
            default:
                break;
        }

    }
}