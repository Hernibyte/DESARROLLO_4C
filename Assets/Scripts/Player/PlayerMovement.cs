using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform dodgePivot;
    [SerializeField] LayerMask environmentMask;
    [Tooltip("The distance between the images on the afterImage effect on dodge")]
    public float distanceBetweenImages;
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
        if(!inDodge)
        {
            dodgePivot.position = transform.position;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            body2D.AddForce(movement * playerStats.forceMovement);
            animator.SetFloat("Velocity", body2D.velocity.magnitude);
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

            MakeAfterImageOnDodge();

            body2D.AddForce(auxMovement * playerStats.dodgeForce);
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
        if(MyUtilities.Contains(environmentMask, other.gameObject.layer) && inDodge)
        {
            inDodge = false;
            body2D.velocity = Vector2.zero;
        }
    }
}
