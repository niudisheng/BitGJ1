using System;
[Serializable]
public enum  States 
{
    idle=0,
    move=1,
    attack=2,
    dead=4,
    rolling=8,
    jump=16,
    fall=32,
    defend=64,
}
[Flags]
public enum AttackType
{
    normal=1,
    throwing=2,
    special=4,
    gun=8,
    
}
[Serializable]
public enum EnemyStateEnum
{
    patrol,chase,rangeAttack
}

public enum UIType
{
    All=4,
    ItemDisplay=0,
    descption=1,
    Dialog=2,
    PauseMenu=3,
    Bag=5,
}

