
using DG.Tweening;
using UnityEngine;
public class Player : CharacterBase
{
    public Play2DInput playertest;
    public Vector2 direction= Vector2.zero;
    public Rigidbody2D rb;
    
    
    public PlayerInteractor interactor;
    public PlayerStateMachine stateMachine;
    public GameObject bag;


    [Header("参数设置")]
    public float forceMagnitude = 10f; // 调整这个值来改变力量大小
    public float speed = 5f; // 调整这个值来改变速度大小
    public float height;
     
    public Weapon weapon;
    [Header("状态")]
    public bool isFirstJump;
    public bool isDoubleJump;
    public bool isGround;

    public bool isDefend
    {
        get { return stateMachine.CheckState(States.defend); }
    }

    private void Awake()
    {
        bag.gameObject.SetActive(false);
        isFirstJump = false;
        isDoubleJump = false;
        playertest = new Play2DInput();
        stateMachine = new PlayerStateMachine();
        


        PlayerState idleState = new IdleState(this,stateMachine);
        // stateMachine = new PlayerStateMachine();
        stateMachine.Initialize(this,idleState);
    }

    private void OnEnable()
    {
        playertest.Enable();
        // playertest.Player.Move.started += ctx => MoveDirection(ctx.ReadValue<Vector2>());
        //绑定输入事件,非常重要
        playertest.Player.Jump.started += ctx => Jump();
        playertest.Player.Roll.started += ctx => roll();
        //playertest.Player.Defend.canceled += ctx =>OutDefend();
        //playertest.Player.Attack.started += ctx =>weapon.executeWeapon();
        //playertest.Player.Throw.started += ctx =>weapon.executeThrow();
        playertest.Player.Interact.started += ctx => Interact();
        playertest.Player.OpenBag.started += ctx => OpenBag();
        
        //weapon.retrieveWeapon = RetrieveWeapon;

    }

    private void OnDisable()
    {
        playertest.Disable();
    }

    private void Update()
    {
        //获取输入
        if (!isDefend)
        {
            direction = playertest.Player.Move.ReadValue<Vector2>();
            MoveDirection(direction);
        }

        if (Input.GetMouseButtonDown(1))
        {
            stateMachine.AddState(new DefendState(this, stateMachine));
        }
        
    }

    public void MoveDirection(Vector2 direction1)
    {
        //基础移动
        if (direction1 == Vector2.zero)
        {
            stateMachine.RemoveState(States.move);
            return;
        }
        stateMachine.AddState(new MoveState(this,stateMachine));
        rb.velocity = new Vector2(direction1.x* speed, rb.velocity.y);
    }

    public void Jump()
    {
        if (!isDefend)
        {
            Debug.Log("jump");
            if (!isFirstJump && isGround && !isDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                stateMachine.AddState(new JumpState(this, stateMachine));
                isFirstJump = true;
            }
            else if (isFirstJump && !isGround && !isDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                stateMachine.AddState(new JumpState(this, stateMachine));
                isDoubleJump = true;
                isFirstJump = false;
            }
            else if (isDoubleJump)
            {
                //isDoubleJump = false;
            }

        }

    }
    public void Interact()
    {
        //interactor.GoInteract();
    }
    public void OpenBag()
    {
        bag.gameObject.SetActive(true);
    }

    /// <summary>
    /// 碰撞地面检测
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb != null&&collision.gameObject.CompareTag("Ground"))
        {
            stateMachine.RemoveState(States.jump);
            isGround = true;
            isDoubleJump= false;
            isFirstJump= false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (rb != null && collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;

        }
    }
    void roll()
    {
        if (!isDefend)
        {
            stateMachine.AddState(new RollingState(this, stateMachine));
        }

    }
    
    private void OutDefend()
    {
        stateMachine.RemoveState(States.defend);
    }

    
    /// <summary>
    /// 冲刺收回武器
    /// </summary>
    public void RetrieveWeapon(Vector2 pos)
    {
        rb.DOMove(pos, 0.1f).onComplete += () => 
        { 
            weapon.isThrown = false;
            weapon.rb.isKinematic = true;
            weapon.rb.velocity = Vector2.zero;
        };
    }


}
