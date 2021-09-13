using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
  [SerializeField] private Transform targetTransform;
  private Vector3 newPosition = Vector3.zero;

  private void Start() {
    newPosition.z = this.transform.position.z;
    UpdatePositionToTarget();
  }

  private void LateUpdate() {
    UpdatePositionToTarget();
  }

  private void UpdatePositionToTarget() {
    newPosition.x = targetTransform.position.x;
    newPosition.y = targetTransform.position.y;

    this.transform.position = newPosition;
  }
}
