using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HoverMovement : MovementInterface
{
    private HoverMovementConfig config;
    private const float DOTOF45DEG = 0.707f;


    public HoverMovement(CharacterController character, HoverMovementConfig config) : base(character)
    {
        this.config = config;
    }

    public override bool OnCollisionEnterIsFail(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Trap")
            return true;

        foreach (ContactPoint2D point in collision.contacts)
        {
            if (DOTOF45DEG > Mathf.Abs( Vector2.Dot(Vector3.up, point.normal)))
            {
                return true;
            }
        }
        return false;
    }

    public override void OnMouseClick()
    {
    }

    public override void OnMouseHold()
    {
        character.rigid.AddForce(Vector3.up * config.boosterStrength * Time.deltaTime);
    }

    public override void OnUpdate()
    {
        character.rigid.velocity = new Vector2(config.moveSpeed, character.rigid.velocity.y);
        Vector3 vec2ToVec3 = character.rigid.velocity.normalized;
        Quaternion rotation = Quaternion.LookRotation(character.transform.position + vec2ToVec3, Vector3.up);
        character.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

}
