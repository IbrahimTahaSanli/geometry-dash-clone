using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [HideInInspector] public static InputController Instance
    {
        get;
        private set;
    }
    
    [HideInInspector] public MovementInterface movement;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            DestroyImmediate(this);                             

        StateController.Instance.AddStateChangeListener(StateListener);
    }

    private void StateListener(StateController.State oldState,  StateController.State newState)
    {
        switch (newState)
        {
            case StateController.State.Play:
                this.enabled = true; 
                break;
            default:
                this.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.OnUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            movement.OnMouseClick();
        }
        if (Input.GetMouseButton(0))
        {
            movement.OnMouseHold();
        }
    }
}
