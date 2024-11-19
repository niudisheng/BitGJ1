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