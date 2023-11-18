using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

/// <summary>
/// Default State in our state machine
/// Tailored for Player right now. See LocomotionState and JumpState as an example.
/// </summary>
public abstract class BaseState : IState
{
    protected readonly PlayerController player;
    protected readonly Animator animator;

    protected static readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    protected static readonly int JumpHash = Animator.StringToHash("Jump");
    protected static readonly int DashHash = Animator.StringToHash("Dash");

    protected const float CROSSFADEDURATION = 0.1f;

    protected BaseState(PlayerController _player, Animator _animator)
    {
        this.player = _player;
        this.animator = _animator;
    }

    public virtual void OnEnter()
    {
        //Not Used
    }

    public virtual void Update()
    {
        //Not Used
    }

    public virtual void FixedUpdate()
    {
        //Not Used
    }

    public virtual void OnExit()
    {
        Debug.Log("BaseState.OnExit");
    }

    
}