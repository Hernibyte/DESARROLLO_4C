using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyStats stats;
    float auxTimer;
    float auxDistante;

    public void Move(Vector2 position)
    {
        float distance = Vector2.Distance(transform.position, position);
        if(auxDistante != distance)
        {
            auxDistante = distance;
            auxTimer = 0f;
        }
        //
        auxTimer += Time.deltaTime * stats.movementForce / auxDistante;
        transform.position = Vector2.Lerp(transform.position, position, auxTimer);
    }
}
