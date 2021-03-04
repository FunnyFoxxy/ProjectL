using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashRange;
    public float speed;
    Vector2 targetPos;
    private Vector2 direction;
    private Animator animator;
    private enum Facing { UP, DOWN, LEFT, RIGHT };
    private Facing FacingDir = Facing.DOWN;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Move();
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        }
        else 
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    void TakeInput()
    {
        direction = Vector2.zero;

        //if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        //{
        //    if(Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.S)))
        //     {
        //        direction += Vector2.down;
        //        direction += Vector2.right;
        //        FacingDir = Facing.RIGHT;
        //    }
        //    else
        //    {
        //        direction += Vector2.up;
        //        direction += Vector2.right;
        //        FacingDir = Facing.RIGHT;
        //    }
        //}
        //else if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        //{
        //    if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.S)))
        //    {
        //        direction += Vector2.down;
        //        direction += Vector2.left;
        //        FacingDir = Facing.LEFT;
        //    }
        //    else
        //    {
        //        direction += Vector2.up;
        //        direction += Vector2.left;
        //        FacingDir = Facing.LEFT;
        //    }
        //}
        //else if(Input.GetKey(KeyCode.D))
        //{
        //    direction += Vector2.right;
        //    FacingDir = Facing.RIGHT;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    direction += Vector2.down;
        //    FacingDir = Facing.DOWN;
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    direction += Vector2.up;
        //    FacingDir = Facing.UP;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    direction += Vector2.left;
        //    FacingDir = Facing.LEFT;
        //}

       
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            FacingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            FacingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            FacingDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            FacingDir = Facing.RIGHT;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            targetPos = transform.position;
            targetPos = Vector2.zero;
            if (FacingDir == Facing.UP)
            {
                targetPos.y = 1;
            }
            else if (FacingDir == Facing.DOWN)
            {
                targetPos.y  = -1;
            }
            else if (FacingDir == Facing.RIGHT)
            {
                targetPos.x = 1;
            }
            else if (FacingDir == Facing.LEFT)
            {
                targetPos.x = -1;
            }
            transform.Translate(targetPos * dashRange);      
        }

    }

    void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);
        
        if (FacingDir == Facing.LEFT)
        {
            animator.SetFloat("xDir", direction.x);
            animator.SetFloat("yDir", 0);
        }
        else if(FacingDir == Facing.RIGHT)
        {
            animator.SetFloat("xDir", direction.x);
            animator.SetFloat("yDir", 0);
        }
        else if(FacingDir == Facing.UP)
        {
            animator.SetFloat("yDir", direction.y);
            animator.SetFloat("xDir", 0);
        }
    
        else if (FacingDir == Facing.DOWN)
        {
            animator.SetFloat("yDir", direction.y);
            animator.SetFloat("xDir", 0);
        }
        //switch (FacingDir)
        //{
        //    case Facing.LEFT:
        //        animator.SetFloat("xDir", direction.x);
        //        break;
        //    case Facing.RIGHT:
        //        animator.SetFloat("xDir", direction.x);
        //        break;
        //    case Facing.UP:
        //        animator.SetFloat("yDir", direction.y);
        //        break;
        //    case Facing.DOWN:
        //        animator.SetFloat("yDir", direction.y);
        //        break;
        //}
        //animator.SetFloat("xDir", direction.x);
        //animator.SetFloat("yDir", direction.y);
    }
}
