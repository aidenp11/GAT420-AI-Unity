using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class AIPatrolState : AIState
{
    Vector3 destination;
    public AIPatrolState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new FloatCondition(agent.destinationDistance, Condition.Predicate.LESS, 0));
        transitions.Add(transition);

        transition = new AIStateTransition(nameof(AIChaseState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transition.AddCondition(new FloatCondition(agent.enemyHealth, Condition.Predicate.GREATER, 0));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Resume();

        var navNode = AINavNode.GetRandomAINavNode();
        destination = navNode.transform.position;
    }

    public override void OnExit()
    {
        agent.movement.MoveTowards(destination);
        //if (Vector3.Distance(agent.transform.position, destination) < 1)
        //{
        //    agent.stateMachine.SetState(nameof(AIIdleState));
        //}

        //var enemies = agent.enemyPerception.GetGameObjects();
        //if (enemies.Length > 0)
        //{
        //    agent.stateMachine.SetState(nameof(AIChaseState));
        //}
    }

    public override void OnUpdate()
    {
        
    }
}
