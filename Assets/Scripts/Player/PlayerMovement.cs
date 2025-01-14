﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform dodgePivot;
    [SerializeField] LayerMask environmentMask;
    [SerializeField] LayerMask enemyMask;
    [Tooltip("The distance between the images on the afterImage effect on dodge")]
    public float distanceBetweenImages;
    public bool canIMove;
    private float lastImagePosX;
    private float lastImagePosY;

    PlayerStats playerStats;
    Rigidbody2D body2D;
    Vector2 movement;
    Vector2 auxMovement;
    bool inDodge;
    Animator animator;
    SpriteRenderer playerSprite;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        animator = GetComponentInChildren<Animator>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        canIMove = true;
    }

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space) && !inDodge && movement != Vector2.zero)
            inDodge = true;
    }

    void FixedUpdate()  
    {
        Movement();
        Dodge();
    }

    public void ImpulseAttack(Vector2 directionImpulse, float impulseForce)
    {
        if (!inDodge)
        {
            body2D.velocity = new Vector2(directionImpulse.x * impulseForce, directionImpulse.y * impulseForce);
        }
    }

    void Movement()
    {
        if(!inDodge && canIMove)
        {
            dodgePivot.position = transform.position;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            body2D.AddForce(movement * playerStats.totalForceMovement, ForceMode2D.Impulse);
            animator.SetFloat("Velocity", body2D.velocity.magnitude);
        }
        if(!canIMove)
        {
            animator.SetFloat("Velocity", body2D.velocity.magnitude);
            inDodge = false;
        }
    }

    void Dodge()
    {
        if(inDodge && canIMove)
        {
            if(movement.x < 0)
                auxMovement.x = -1;
            else if(movement.x > 0)
                auxMovement.x = 1;
            else 
                auxMovement.x = 0;
            //
            if(movement.y < 0)
                auxMovement.y = -1;
            else if(movement.y > 0)
                auxMovement.y = 1;
            else 
                auxMovement.y = 0;
            //

            MakeAfterImageOnDodge();

            body2D.AddForce(auxMovement * playerStats.dodgeForce, ForceMode2D.Impulse);
            if(Vector2.Distance(transform.position, dodgePivot.position) >= playerStats.dodgeDistance)
            {
                body2D.velocity = Vector2.zero;
                inDodge = false;
            }
        }
    }

    void MakeAfterImageOnDodge()
    {
        animator.SetTrigger("Dodge");

        if (Mathf.Abs(transform.position.x - lastImagePosX) > distanceBetweenImages ||
                    Mathf.Abs(transform.position.y - lastImagePosY) > distanceBetweenImages)
        {
            PlayerAfterImagePool.Instance.GetFromPool();
            lastImagePosX = transform.position.x;
            lastImagePosY = transform.position.y;
        }
    }

    public void ChangeSideSprite(Transform direction)
    {
        if (playerSprite.flipX && direction.up.x > 0)
            playerSprite.flipX = false;
        else if (!playerSprite.flipX && direction.up.x < 0)
            playerSprite.flipX = true;
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if(MyUtilities.Contains(environmentMask, other.gameObject.layer) && inDodge )
        {
            inDodge = false;
            body2D.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(MyUtilities.Contains(enemyMask, other.gameObject.layer) && inDodge)
        {
            inDodge = false;
            body2D.velocity = Vector2.zero;
        }
    }
}
