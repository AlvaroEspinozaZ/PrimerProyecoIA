using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;

[RequireComponent(typeof(BehaviorTree))]
public class AICharacterControl : MonoBehaviour
{
    protected ThirdPersonCharacterAnimatorBase character;
    protected AIEyeBase _AiEye;
    protected Health health;
    public Health Health { get => health; }
   
    public SoundCharacter soundCharacter;
    public virtual void LoadComponent()
    {
      
    }
}
