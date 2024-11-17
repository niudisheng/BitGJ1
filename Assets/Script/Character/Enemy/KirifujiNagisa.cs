using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirifujiNagisa : Enemy
{

    protected override void Awake()
    {
        base.Awake();
        patrolState = new PatrolState();
        chaseState = new ChaseState();
        rangeAttackState = new RangedAttackState();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
