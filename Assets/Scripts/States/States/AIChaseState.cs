using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseState : AIState
{
    float initialSpeed;

    public AIChaseState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIAttackState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transition.AddCondition(new FloatCondition(agent.enemyDistance, Condition.Predicate.LESS, 1));
        transition.AddCondition(new FloatCondition(agent.enemyHealth, Condition.Predicate.GREATER, 0));
        transitions.Add(transition);

        transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new BoolCondition(agent.enemySeen, false));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Resume();
        initialSpeed = agent.movement.maxSpeed;
        agent.movement.maxSpeed *= 1.5f;
    }

    public override void OnUpdate()
    {
        if (agent.enemySeen) agent.movement.Destination = agent.enemy.transform.position;
    }

    public override void OnExit()
    {
        agent.movement.maxSpeed = initialSpeed;
    }
}
