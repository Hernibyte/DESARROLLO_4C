using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        //Daño
        Debug.Log("Hola");
    }
}
