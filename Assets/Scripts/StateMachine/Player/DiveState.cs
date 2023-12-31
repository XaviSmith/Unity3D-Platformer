using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class DiveState : BaseState
{
    public DiveState(PlayerController _player, Animator _animator, PlayerParticles _particles, PlayerSounds _playerSounds) : base(_player, _animator, _particles, _playerSounds) { }

    //On Enter start the jump animation
    public override void OnEnter()
    {
        playerSounds.PlaySound(playerSounds.DiveSound);
        base.OnEnter();
        animator.CrossFade(DiveHash, CROSSFADEDURATION);
        player.StartDive();
        particles.ToggleRunFX(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        particles.ToggleRunFX(false);
        player.ResetDiveVelocity();
    }

    public override void FixedUpdate()
    {
        //call Player's jump logic and move logic
        player.HandleDive();
        player.HandleVerticalMovement();
    }
}
