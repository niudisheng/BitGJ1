using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    private string _weaponName;
    public string weaponName
    {
        get
        {
            if (_weaponName == null)
            {
                return this.name;
            }
            return _weaponName;
            
        }
        set { _weaponName = value; }
    
    }
    public AttackType attackType;
    public float damage;
    //这是冷却
    public float executeRate;
    public float speed;

}
