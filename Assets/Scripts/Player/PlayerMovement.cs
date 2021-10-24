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
        if(Input.GetKeyDown(KeyCode.Space) && !inDodge && movement != Vector2.zero)
            inDodge = true;
    }

    void FixedUpdate()  
    {
        Movement();
        Dodge();
    }

    void Movement()
    {
        if(!inDodge)
        {
            dodgePivot.position = transform.position;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            body2D.AddForce(movement * playerStats.forceMovement);
            if(movement.x == 0)
                body2D.velocity = new Vector2(0f, body2D.velocity.y);
            if(movement.y == 0)
                body2D.velocity = new Vector2(body2D.velocity.x, 0f);
        }
    }

    void Dodge()
    {
        if(inDodge)
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
            body2D.AddForce(auxMovement * playerStats.dodgeForce);
            if(Vector2.Distance(transform.position, dodgePivot.position) >= playerStats.dodgeDistance)
            {
                body2D.velocity = Vector2.zero;
                inDodge = false;
            }
        }
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if(MyUtilities.Contains(environmentMask, other.gameObject.layer) && inDodge)
        {
            inDodge = false;
            body2D.velocity = Vector2.zero;
        }
    }
}
