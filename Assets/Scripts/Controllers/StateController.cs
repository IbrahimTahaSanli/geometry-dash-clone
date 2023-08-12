using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [HideInInspector]
    public static StateController Instance
    {
        get;
        private set;
    }

    public enum State
    {
        Start,
        Play,
        Stop,
        Success,
        Fail
    }

    private State _state;
    public State state
    {
        get { return _state; }
        set { 
            this.InvokeStateChangeEvent(_state, value);
            Debug.Log(value);
            _state = value;
        }
    }

    private List<StateChangeListener> stateChangeListener = new List<StateChangeListener>();

    public delegate void StateChangeListener(State oldState, State newState);

    public void AddStateChangeListener(StateChangeListener listener)
    {
        this.stateChangeListener.Add(listener);
    }

    public void RemoveStateChangeListener(StateChangeListener listener)
    {
        this.stateChangeListener.Remove(listener);
    }

    private void InvokeStateChangeEvent(State oldState, State newState)
    {
        stateChangeListener.ForEach(listener=>listener.Invoke(oldState, newState));
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    public void Start()
    {
        this.state = State.Start;
    }

    public void StartGame()
    {
        if (this.state == State.Start)
            this.state = State.Play;
    }
}
