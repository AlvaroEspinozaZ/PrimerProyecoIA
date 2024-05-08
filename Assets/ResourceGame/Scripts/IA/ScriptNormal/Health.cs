using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeUnit { Zombie, Soldier, None }
public class Health : MonoBehaviour
{

    public TypeUnit _Unit;
    public int isDead;

    public bool IsDead { get => isDead == 0; }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
