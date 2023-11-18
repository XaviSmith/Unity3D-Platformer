using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class DashState : BaseState
{
    public DashState(PlayerController _player, Animator _animator) : base(_player, _animator) { }

    //On Enter start the jump animation
    public override void OnEnter()
    {
        Debug.Log("DashState.OnEnter");
        animator.CrossFade(DashHash, CROSSFADEDURATION);
    }

    public override void FixedUpdate()
    {
        //call Player's move logic since dashing is just a speed modifier for now.
        player.HandleMovement();
    }
}