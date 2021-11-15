using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemyStats stats;
    Rigidbody2D body2D;
    SpriteRenderer enemySprite;
    float auxTimer;
    float auxDistante;
    bool stopMove = false;

    private void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Move(Vector2 position)
    {
        if (stopMove)
            return;

        float distance = Vector2.Distance(transform.position, position);
        if(auxDistante != distance)
        {
            auxDistante = distance;
            auxTimer = 0f;
        }
        //
        auxTimer += Time.deltaTime * stats.movementForce / auxDistante;
        transform.position = Vector2.Lerp(transform.position, position, auxTimer);

        if (position.x > transform.position.x)
            enemySprite.flipX = true;
        else
            enemySprite.flipX = false;
    }

    public void ImpulseAttack(Vector2 directionImpulse, float impulseForce)
    {
        body2D.velocity = new Vector2(directionImpulse.x * impulseForce, directionImpulse.y * impulseForce);
    }

    public void StopMove()
    {
        stopMove = true;
    }

    public void RestoreMove()
    {
        stopMove = false;
    }
}
