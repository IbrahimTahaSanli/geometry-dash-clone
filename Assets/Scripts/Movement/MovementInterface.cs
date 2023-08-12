using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementInterface
{
    public CharacterController character;

    public MovementInterface(CharacterController character)
    {
        this.character = character;
    }

    public abstract void OnMouseClick();
    public abstract void OnMouseHold();
    public abstract void OnUpdate();

    public abstract bool OnCollisionEnterIsFail(Collision2D collision);
}
