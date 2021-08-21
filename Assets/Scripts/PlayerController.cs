using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody2D playerRigidBody;

  void Start()
  {
    playerRigidBody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
