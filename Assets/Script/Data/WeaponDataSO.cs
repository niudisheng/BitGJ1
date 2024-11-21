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
    [Header("攻击类型")]
    public AttackType attackType;
    [Header("攻击力")]
    public float damage;
    [Header("冷却时间")]
    public float executeRate;
    [Header("投掷物飞出的速度")]
    public float speed;

}
