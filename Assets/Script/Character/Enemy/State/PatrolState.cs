using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.speed = currentEnemy.patrolSpeed;
        Debug.Log("patrol");
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.FoundPlayer())
        {
            if(currentEnemy.playerDistance>=10)
                currentEnemy.SwitchState(EnemyStateEnum.chase);
            else
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
