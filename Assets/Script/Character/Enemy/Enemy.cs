using DG.Tweening.CustomPlugins;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public PhysicsCheck PhysicsCheck;
    public Transform player;
    [HideInInspector] public Vector3 dir;
    [Header("基本参数")]
    public float patrolSpeed;
    public float chaseSpeed;
    public float speed;
    [Header("状态")]
    public bool isWait;
    public bool isHurt;
    public bool isRangeAttack;
    [Header("计时器")]
    public float waitTime;
    public float waitTimeCounter;
    [Header("检测玩家")]
    public Vector2 centerOffSet;
    public Vector2 checkSize;
    public float checkDistance;
    public float playerDistance;
    public LayerMask attackLayer;
    

    private EnemyState currentState;
    protected EnemyState patrolState;
    protected EnemyState chaseState;
    protected EnemyState rangeAttackState;
    protected virtual void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        patrolState = new PatrolState();
        waitTimeCounter =waitTime;
    }
    private void OnEnable()
    {
        currentState = patrolState;
        currentState.OnEnter(this);
    }
    protected virtual void Update()
    {
        dir = new Vector3(-transform.localScale.x, 0, 0).normalized;
        if (isWait)
            WaitTimeCounter();
        currentState.LogicUpdate();

    }
    private void FixedUpdate()
    {
        playerDistance = Mathf.Sqrt(Mathf.Pow( player.position.x - transform.position.x,2)+ Mathf.Pow(player.position.y - transform.position.y, 2));
        if (!isWait&&!isRangeAttack)
        {

            Move();
        }
        currentState.PhysicUpdate();
    }
    private void OnDisable()
    {
        currentState.OnExit();
    }
    public void Move()
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }
    public void WaitTimeCounter()
    {
        rb.velocity = Vector2.zero;
        waitTimeCounter -= Time.deltaTime;
        if (waitTimeCounter <= 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x,1,1);
            PhysicsCheck.bottomOffSet1 = new Vector2(-PhysicsCheck.bottomOffSet1.x, PhysicsCheck.bottomOffSet1.y);
            PhysicsCheck.bottomOffSet2 = new Vector2(-PhysicsCheck.bottomOffSet2.x, PhysicsCheck.bottomOffSet2.y);
            isWait = false;
            waitTimeCounter = waitTime;
        }
        if(PhysicsCheck.isGround&&!PhysicsCheck.isWall)
        {
            isWait = false;
            waitTimeCounter = waitTime;
        }
    }
    public bool FoundPlayer()
    {
        return Physics2D.BoxCast(transform.position+(Vector3)centerOffSet,checkSize,0,dir,checkDistance,attackLayer);
    }
    public void SwitchState(EnemyStateEnum State)
    {
        var newState = State switch
        {
            EnemyStateEnum.patrol => patrolState,
            EnemyStateEnum.chase => chaseState,
            EnemyStateEnum.rangeAttack => rangeAttackState,
            _ => null
        };

        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter(this);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)centerOffSet+new Vector3(checkDistance*-transform.localScale.normalized.x,0,0),0.2f);
    }
}
