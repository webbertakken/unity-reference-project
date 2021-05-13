using UnityEngine;

public class Player : MonoBehaviour
{
  CharacterController _characterController;
  IMover _mover;
  Rotator _rotator;
  public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

  void Awake() {
    _characterController = GetComponent<CharacterController>();
    _mover = new Mover(this);
    // _mover = new NavmeshMover(this);
    _rotator = new Rotator(this);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      _mover = new Mover(this);
    }

    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      _mover = new NavmeshMover(this);
    }

    _mover.Tick();
    _rotator.Tick();
  }
}
