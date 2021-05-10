using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonMover : MonoBehaviour
{
  [SerializeField]
  float _turnSpeed = 1000f;
  [SerializeField]
  float _moveSpeed = 5f;
  Rigidbody _rigidbody;

  void Awake() {
    _rigidbody = GetComponent<Rigidbody>();
  }

  void Update() {
    var mouseMovement = Input.GetAxis("Mouse X");
    transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    var velocity = new Vector3(horizontal, 0, vertical);
    velocity *= _moveSpeed * Time.fixedDeltaTime;

    var offset = transform.rotation * velocity;

    _rigidbody.MovePosition(transform.position + offset);
  }
}
