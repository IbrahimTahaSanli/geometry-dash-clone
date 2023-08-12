using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minHeight;
    [SerializeField] private Vector3 cameraOffset;

    [SerializeField] private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        StateController.Instance.AddStateChangeListener(StateListener);
    }

    private void StateListener(StateController.State oldState, StateController.State newState){
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
        Vector3 vec = CharacterController.Instance.transform.position + cameraOffset;
        vec.y = vec.y < minHeight ? minHeight : vec.y;
        this.camera.transform.position = vec;
    }
}
