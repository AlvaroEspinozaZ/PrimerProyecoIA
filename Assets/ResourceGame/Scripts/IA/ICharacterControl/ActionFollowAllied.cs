using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionFollowAllied : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterAction.Health.IsDead)
            return TaskStatus.Failure;

        SwitchMoveToAllied();

        return TaskStatus.Success;
    }
    void SwitchMoveToAllied()
    {
        switch (Unit)
        {
            case TypeUnit.Policia:
                //if()
                break;
            case TypeUnit.None:
                break;
            default:
                break;
        }
    }
}
