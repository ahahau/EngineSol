using System;
using _01.Code.Enemies;
using _01.Code.Manager;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Nav to Target", story: "[NavMovement] To [Target]", category: "Action", id: "7bcf070f6b72176c22904688262e647c")]
public partial class NavToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMovement> NavMovement;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnStart()
    {
        if (Target.Value == null)
            Target.Value = GameManager.Instance.CenterTower.gameObject;
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

