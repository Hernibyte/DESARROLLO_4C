using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IHitabble
{
    //void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker);

    void ReciveHit(int amountHeartsDmg, float knockBackForce, Vector2 posAttacker);

}

public interface INode
{
    
}