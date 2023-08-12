using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalComponent : MonoBehaviour
{
    [SerializeField] public MovementTypes type;
    [SerializeField] public ScriptableObject config;

    public void SetPortalMovement(CharacterController controller)
    {
        switch (type)
        {
            case MovementTypes.Jump:
                InputController.Instance.movement = new JumpMovement(controller, (JumpMovementConfig)config);
                break;
            case MovementTypes.Hover:
                InputController.Instance.movement = new HoverMovement(controller, (HoverMovementConfig)config);
                break;
        }
    }
}
