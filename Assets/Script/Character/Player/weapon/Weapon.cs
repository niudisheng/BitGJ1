using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    
    public WeaponDataSO weaponData;
    //是否冷却
    public bool isCooldown;
    //冷却时间
    private float executeRate;
    public bool isThrown = false;
    //固定值，让瓦逸自己来改
    protected float offset = -90f;
    protected Rigidbody2D rb;
    //以下用于计算投掷物的速度和方向
    protected Vector3 difference;
    public UnityAction<Vector2> retrieveWeapon;
    private void Awake()
    {
        executeRate = weaponData.executeRate;
        isCooldown = true;
    }
    
    private void Start()
    {
        
        rb = this.GetComponent<Rigidbody2D>();
    }
    protected virtual void onExecute()
    {
        
    }

    protected virtual void Retrieve()
    {
        retrieveWeapon(this.transform.position);
    }

    protected virtual void onThrow()
    {
        
        if (isThrown)
        {
            //TODO: 实现跟踪收回丢出物体
            Retrieve();
        }
        else
        {
            rb.velocity = difference * weaponData.speed;
            Debug.LogWarning(rb.velocity);
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;
            isThrown = true;
        }
    }
    
    /// <summary>
    /// 执行投掷效果
    /// </summary>
    public virtual void executeThrow()
    {
        
        onThrow();
    }

    public virtual void executeWeapon()
    {
        
        if (isCooldown)
        {
            onExecute();
            Debug.Log("Execute");
            waitForCooldown();
        }
    }

    public virtual void waitForCooldown()
    {
        isCooldown = false;
        Debug.Log(DelayedAction.instance);
        DelayedAction.instance.StartDelayedAction(executeRate, () =>
            {
                isCooldown = true;
            }
        );
    }



}