﻿using UnityEngine;
using CharacterStateMachine;
internal class ClimbState : State
{
    public ClimbState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        _character._animator.SetBool("Climb", true);
    }

    public override void Exit()
    {
        _character._animator.SetBool("Climb", false);
    }

    public override void LogicUpdate()
    {
        if (_character._isGrounded)
        {
            _stateMachine.ChangeState(_character._groundState);
        }
    }

    public override void PhysicsUpdate()
    {
        _character._wallClimb = new Vector3(_character._direction.x * _character._climbForceX, _character._climbForceY);
        _character._characterController.Move(_character._wallClimb * Time.fixedDeltaTime);
    }
}

