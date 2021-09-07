using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private enum States
  {
    IDLE,
    WALKING
  }

  [SerializeField] private float playerSpeed = 250;

  private Rigidbody2D playerRigidBody;
  private Animator playerAnimator;
  private Vector2 movementVector = Vector2.zero;
  private Vector2 rawInputMovement = Vector2.zero;
  private States currentState = States.IDLE;

  private void Awake()
  {
    playerRigidBody = GetComponent<Rigidbody2D>();
    playerAnimator = GetComponent<Animator>();
  }

  private void Update()
  {
    KeepMovementProportionalToFramerate();

    switch (currentState)
    {
      case States.IDLE:
        PlayAnimation(States.IDLE);
        break;
      case States.WALKING:
        PlayAnimation(States.WALKING);
        break;
    }
  }

  private void FixedUpdate()
  {
    switch (currentState)
    {
      case States.IDLE:
        Stop();
        break;
      case States.WALKING:
        Move();
        break;
    }  
  }

  private void KeepMovementProportionalToFramerate()
  {
    movementVector = rawInputMovement * playerSpeed * Time.deltaTime;
  }
  
  private void Stop()
  {
    playerRigidBody.velocity = Vector2.zero;
  }

  private void Move()
  {
    playerRigidBody.velocity = movementVector;
  }


  private void PlayAnimation(States animationToPlay)
  {
    if (animationToPlay == States.IDLE)
    {
      playerAnimator.speed = 0;
    }
    else if (animationToPlay == States.WALKING)
    {
      playerAnimator.speed = 1;

      if (rawInputMovement.y > 0)
      {
        playerAnimator.Play("WalkingNorth", 0);
      }
      else if (rawInputMovement.y < 0)
      {
        playerAnimator.Play("WalkingSouth", 0);
      }
      else if (rawInputMovement.x > 0)
      {
        playerAnimator.Play("WalkingWest", 0);
      }
      else if (rawInputMovement.x < 0)
      {
        playerAnimator.Play("WalkingEast", 0);
      }
    }
  }

  public void OnActionMovement(InputAction.CallbackContext context)
  {
    rawInputMovement = context.ReadValue<Vector2>();

    if (rawInputMovement == Vector2.zero)
    {
      currentState = States.IDLE;
    }
    else
    {
      currentState = States.WALKING;
    }
  }
}
