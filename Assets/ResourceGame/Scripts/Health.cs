using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Zombie, Policia,None};
public class Health : MonoBehaviour
{
    public TypeUnit Unit;
    public int health;
    public bool IsDead { get => health == 0; }
}
