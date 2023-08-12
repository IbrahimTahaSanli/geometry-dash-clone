using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector]
    public static CharacterController Instance
    {
        get;
        private set;
    }

    [SerializeField] public Rigidbody2D rigid;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (InputController.Instance.movement.OnCollisionEnterIsFail(collision))
        {
            ConfigController.Instance.IncDeathCounter();
            rigid.isKinematic = true;
            StateController.Instance.state = StateController.State.Fail;
        }
        else
        {
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0;
            rigid.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag){
            case "Portal":
                rigid.angularVelocity = 0;

                PortalComponent component = collision.GetComponent<PortalComponent>();
                component.SetPortalMovement(this);
                break;

            case "FinishLine":
                StateController.Instance.state = StateController.State.Success;
                break;
        }
    }
}
