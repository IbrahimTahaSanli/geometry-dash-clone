using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MovementInterface
{
    public JumpMovementConfig config;

    private bool canJump = true;
    private const float DOTOF45DEG = 0.707f;

    public JumpMovement(CharacterController character, JumpMovementConfig config): base(character)
    {
        this.config = config;
    }

    public override void OnMouseClick()
    {
        if (canJump)
        {
            character.rigid.AddForce(Vector3.up * config.jumpStrength);
            character.rigid.AddTorque(config.rotateSpeed);

            canJump = false;
        }
    }

    public override void OnMouseHold()
    {
    }

    public override void OnUpdate()
    {
        character.rigid.velocity = new Vector2( config.moveSpeed, character.rigid.velocity.y);
    }

    public override bool OnCollisionEnterIsFail(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Trap")
            return true;

        foreach (ContactPoint2D point in collision.contacts)
        {
            if (DOTOF45DEG > Vector2.Dot(Vector3.up, point.normal))
            {
                return true;
            }
        }
        canJump = true;
        return false;
    }

}
