using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform dodgePivot;
    [SerializeField] LayerMask environmentMask;
    PlayerStats playerStats;
    Rigidbody2D body2D;
    Vector2 movement;
    Vector2 auxMovement;
    bool inDodge;

    void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {   
        Dodge();
    }

    void FixedUpdate()  
    {
        Movement();
    }

    void Movement()
    {
        if(!inDodge)
        {
            dodgePivot.position = transform.position;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            body2D.AddForce(movement * playerStats.forceMovement);
        }
    }

    void Dodge()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !inDodge)
        {
            inDodge = true;
            auxMovement = movement;
        }
        if(inDodge)
        {
            body2D.AddForce(auxMovement * playerStats.dodgeForce);
            if(Vector2.Distance(transform.position, dodgePivot.position) >= playerStats.dodgeDistance)
            {
                body2D.velocity = Vector2.zero;
                inDodge = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(MyUtilities.Contains(environmentMask, other.gameObject.layer))
        {
            inDodge = false;
        }
    }
}
