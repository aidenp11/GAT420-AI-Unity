using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIDeathState : AIState
{
    float timer = 0;

    public AIDeathState(AIStateAgent agent) : base(agent)
    {
    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;

        agent.animator?.SetTrigger("Death");
    }
    public override void OnUpdate()
    {
        timer = Time.time + 2;
        if (Time.time > timer)
        {
            agent.gameObject.SetActive(false);
        }
    }

    public override void OnExit()
    {
        
    }

}
