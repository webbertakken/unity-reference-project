using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ThirdPersonMover : MonoBehaviour
{
  [SerializeField]
  float _turnSpeed = 1000f;
  [SerializeField]
  float _moveSpeed = 5f;
  Rigidbody _rigidbody;

  Animator _animator;
  static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
  static readonly int HorizontalSpeed = Animator.StringToHash("HorizontalSpeed");

  void Awake() {
    _rigidbody = GetComponent<Rigidbody>();
    _animator = GetComponent<Animator>();
  }

  void Update() {
    var mouseMovement = Input.GetAxis("Mouse X");
    transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
  }

  void FixedUpdate() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    bool sprinting = Input.GetKey(KeyCode.LeftShift);
    if (sprinting) {
      vertical *= 2f;
    }

    var velocity = new Vector3(horizontal, 0, vertical);
    velocity.Normalize();
    velocity *= _moveSpeed * Time.fixedDeltaTime;

    var offset = transform.rotation * velocity;

    _rigidbody.MovePosition(transform.position + offset);
    _animator.SetFloat(VerticalSpeed, vertical, 0.1f, Time.fixedDeltaTime);
    _animator.SetFloat(HorizontalSpeed, horizontal, 0.1f, Time.fixedDeltaTime);
  }
}
