using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float playerSpeed = 3000;

  private Vector2 movementVector = Vector2.zero;
  private Rigidbody2D playerRigidBody;

  private void Awake() 
  {
    playerRigidBody = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate() 
  {
    HandlePlayerMovement();
  }

  private void HandlePlayerMovement()
  {
    playerRigidBody.velocity = movementVector * Time.deltaTime;
    // playerRigidBody.AddForce(movementVector);
  }

  public void OnActionMovement(InputAction.CallbackContext context) 
  {
    Vector2 rawInputMovement = context.ReadValue<Vector2>();

    movementVector = rawInputMovement * playerSpeed;
  }
}
