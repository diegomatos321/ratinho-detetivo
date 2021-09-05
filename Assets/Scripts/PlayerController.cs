using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float playerSpeed = 250;

  private Rigidbody2D playerRigidBody;
  private Vector2 movementVector = Vector2.zero;
  private Vector2 rawInputMovement = Vector2.zero;

  private void Awake() 
  {
    playerRigidBody = GetComponent<Rigidbody2D>();
  }

  private void Update() {
    KeepMovementProportionalToFramerate();
  }

  private void FixedUpdate() 
  {
    HandlePlayerMovement();
  }

  private void KeepMovementProportionalToFramerate() 
  {
    movementVector = rawInputMovement * playerSpeed * Time.deltaTime;
  }

  private void HandlePlayerMovement()
  {
    playerRigidBody.velocity = movementVector;
    // playerRigidBody.AddForce(movementVector);
  }

  public void OnActionMovement(InputAction.CallbackContext context) 
  {
    rawInputMovement = context.ReadValue<Vector2>();
  }
}
