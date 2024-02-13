using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class AIIdleState : AIState
{


    public AIIdleState(AIStateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIPatrolState));
        transition.AddCondition(new FloatCondition(agent.timer, Condition.Predicate.LESS, 0));
        transitions.Add(transition);

        transition = new AIStateTransition(nameof(AIChaseState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;

        agent.timer.value = Random.Range(1, 2);
    }
    public override void OnUpdate()
    {
        foreach(var transition in transitions)
        {
            if (transition.ToTransition())
            {
                agent.stateMachine.SetState(transition.nextState);
            }
        }

        
    }

    public override void OnExit()
    {
        
    }

}
