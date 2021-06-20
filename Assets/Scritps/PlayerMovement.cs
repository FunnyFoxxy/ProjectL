using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Пеубличные переменные
    public float dashRange;
    public float speed;
    public bool boostSpeed;
    //локальные
    Vector2 targetPos;
    private Vector2 direction;
    private Animator animator;
    private enum Facing { UP, DOWN, LEFT, RIGHT };
    private Facing FacingDir = Facing.DOWN;
    PlayerStats playerStatsScript;
    float run = 1;
    bool isRun;
    public GameObject MiniMap;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerStatsScript = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Move();
    }

    void Move() //Передвижение в зависсимости от нажатой клавиши 
    {
        transform.Translate(direction * speed * Time.deltaTime * run);

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        }
        else 
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    void TakeInput() //Управление
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftControl)) //Открытие карты
        {
            MiniMap.SetActive(true);

        }
        else
        {
            MiniMap.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))//Управление
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
        if(Input.GetKeyDown(KeyCode.Q)) //Возаимодействие
        {
            PlayerStats.playerStats.KeyButtonPushed = true;
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            PlayerStats.playerStats.KeyButtonPushed = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && playerStatsScript.staminaSlider.value > 10)
        {
            run = 2f;
            isRun = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = 1;
            isRun = false;
        }
        if (boostSpeed == true)
        {
            speed = 2f;
        }
        //else
        //{
        //    speed = 1;
        //    if (playerStatsScrpt.staminSlider.value < playerStatsScrpt.staminSlider.maxValue)
        //    {
        //        playerStatsScrpt.staminSlider.value -= 0.5f;
        //    }
        //}
        if(isRun == true)
        {
            playerStatsScript.staminaSlider.value -= 0.3f;
        }
        else
        {
            speed = 1;
        }
        
       

    }

    void SetAnimatorMovement(Vector2 direction) //Повороты персонажа 
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
        
    }
}
