using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.isRangeAttack = true;
        Debug.Log("rangeattack");
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.playerDistance >= 10)
            currentEnemy.SwitchState(EnemyStateEnum.chase);
        else if (currentEnemy.playerDistance >= 15)
            currentEnemy.SwitchState(EnemyStateEnum.patrol);
        
        if (currentEnemy.PhysicsCheck.isWall || !currentEnemy.PhysicsCheck.isGround)
        {
            currentEnemy.isWait = true;
        }
    }
    public override void PhysicUpdate()
    {

    }
    public override void OnExit()
    {
        currentEnemy.isRangeAttack=false;
    }
}
