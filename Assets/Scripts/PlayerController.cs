using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float playerSpeed = 250;

  private PlayerInputsActions playerInputsActions;
  private InputAction movementInput;
  private Vector2 velocityVector = Vector2.zero;
  private Rigidbody2D playerRigidBody;

  private void Awake() 
  {
    playerInputsActions = new PlayerInputsActions();
    playerRigidBody = GetComponent<Rigidbody2D>();
  }

  private void OnEnable() 
  {
    movementInput = playerInputsActions.OnFoot.Movement;
    movementInput.Enable();
  }

  private void FixedUpdate() 
  {
    HandlePlayerMovement();
    Debug.Log("Velocidade: " + velocityVector);
  }

  private void HandlePlayerMovement()
  {
    Vector2 inputVector = movementInput.ReadValue<Vector2>();

    velocityVector.x = playerSpeed * inputVector.x * Time.deltaTime;
    velocityVector.y = playerSpeed * inputVector.y * Time.deltaTime;

    // playerRigidBody.AddForce(velocityVector);
    playerRigidBody.velocity = velocityVector;
  }

  private void OnDisable() 
  {
    movementInput.Disable();
    playerInputsActions.OnFoot.Movement.Disable();
  }

}
