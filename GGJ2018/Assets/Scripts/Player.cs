using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool canMove = true;
    public float speed = 10f;
    public Vector2 maxVelocity = new Vector2(60, 100);
    public float jumpSpeed = 200f;
    public bool standing;
    public float standingThreshold = 4f;
    public float airSpeedMultiplier = .3f;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);

        if (absVelY <= standingThreshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        var forceX = 0f;
        var forceY = 0f;

        if (controller.moving.x != 0)
        { //move right
            if (absVelX < maxVelocity.x)
            {

                var newSpeed = speed * controller.moving.x;


                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);

                renderer2D.flipX = forceX < 0; //flip when changing direction line 1
            }
            animator.SetInteger("Animator", 1);
        }
        else
        {
            animator.SetInteger("Animator", 3);
        }

        if (controller.moving.y > 0)
        { //originally get key and changed to get key down
            if (absVelY < maxVelocity.y)
            {
                forceY = jumpSpeed * controller.moving.y;
                animator.SetInteger("Animator", 2);
            }

        }
        else if (absVelY > 0 && !standing)
        { //animates falling after a jump
        }

        body2D.AddForce(new Vector2(forceX, forceY));


    }
    public void SetCanMove(bool yesOrNo)
    {
        canMove = yesOrNo;
    }
}
