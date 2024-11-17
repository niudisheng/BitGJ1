using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.speed = currentEnemy.chaseSpeed;
        Debug.Log("chase");
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.FoundPlayer())
        {
            if (currentEnemy.playerDistance >= 15)
                currentEnemy.SwitchState(EnemyStateEnum.patrol);
            else if (currentEnemy.playerDistance <= 10)
                currentEnemy.SwitchState(EnemyStateEnum.rangeAttack);
        }
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
        
    }
}
