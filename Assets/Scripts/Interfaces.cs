using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHitabble
{
    void ReciveDamage(int amountDamage, float knockBackForce, Vector2 posAttacker);
}

public interface INode
{
    
}