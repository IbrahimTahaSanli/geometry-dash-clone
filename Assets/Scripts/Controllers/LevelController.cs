using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CharacterController controller; 
    [SerializeField] private MovementTypes type;
    [SerializeField] private ScriptableObject config;
    [SerializeField][Min(0)] private float resetTimer;

    public void Start()
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

        StateController.Instance.state = StateController.State.Play;
        StateController.Instance.AddStateChangeListener(StateListener);
    }

    private void StateListener(StateController.State oldState, StateController.State newState) { 
        if(newState == StateController.State.Fail)
            StartCoroutine(ResetScene());

    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(resetTimer);
        SceneManager.LoadScene("Level1");
    }
}
