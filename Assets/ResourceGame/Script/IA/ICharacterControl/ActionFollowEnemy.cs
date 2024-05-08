using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]

public class ActionFollowEnemy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (_AICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchMoveToEnemy();
        return TaskStatus.Success;
       
    }
    void SwitchMoveToEnemy()
    {
        switch (Unit)
        {
            case TypeUnit.Soldier:
                if (_AICharacterVehicle is AICharacterVehicleSoldier)
                {
                    ((AICharacterVehicleSoldier)_AICharacterVehicle).MoveToEnemy();
                }
                break;
            case TypeUnit.None:
                break;
            default:
                break;
        }
        
    }
}
