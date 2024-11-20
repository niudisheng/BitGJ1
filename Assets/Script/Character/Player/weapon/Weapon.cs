using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO weaponData;
    
    public bool isCooldown;
    private float executeRate;
    private void Awake()
    {
        executeRate = weaponData.executeRate;
        isCooldown = true;
    }

    protected virtual void onExecute()
    {
        
    }
//TODO: 加入Q键的区分
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