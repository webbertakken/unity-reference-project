using UnityEngine;

public class PlayerInput : IPlayerInput
{
  public float Vertical => Input.GetAxis("Vertical");
  public float Horizontal => Input.GetAxis("Horizontal");
  public float MouseX => Input.GetAxis("Mouse X");
  public float MouseY => Input.GetAxis("Mouse Y");
}
