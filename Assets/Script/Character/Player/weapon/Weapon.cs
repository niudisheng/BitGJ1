using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO weaponData;
    
    public bool isCooldown;
    private float executeRate;
    private void Start()
    {
        executeRate = weaponData.executeRate;
        isCooldown = true;
    }

    protected virtual void onExecute()
    {
        Debug.Log("Execute");
    }

    public virtual void executeWeapon()
    {
        onExecute();
        waitForCooldown();
    }

    public virtual void waitForCooldown()
    {
        isCooldown = false;
        DelayedAction.instance.StartDelayedAction(executeRate, () =>{
            {
                isCooldown = true;
            }
        });
    }



}