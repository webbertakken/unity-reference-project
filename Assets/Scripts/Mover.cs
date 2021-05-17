using UnityEngine;
using UnityEngine.AI;

public class NavmeshMover : IMover
{
  readonly Player _player;
  readonly NavMeshAgent _navmeshAgent;

  public NavmeshMover(Player player) {
    _player = player;
    _navmeshAgent = _player.GetComponent<NavMeshAgent>();
    // Todo - cleanup
    _navmeshAgent.enabled = true;
  }
  public void Tick() {
    if (Input.GetMouseButtonDown(0))
    {
      if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo)) {
        _navmeshAgent.SetDestination(hitInfo.point);
      }
    }
  }
}
public class Mover : IMover
{
  readonly Player _player;
  readonly CharacterController _characterController;

  public Mover(Player player) {
    _player = player;
    _characterController = player.GetComponent<CharacterController>();
    // Todo - remove me
    _player.GetComponent<NavMeshAgent>().enabled = false;
  }

  public void Tick() {
    Vector3 movementInput = new Vector3(_player.PlayerInput.Horizontal, 0, _player.PlayerInput.Vertical);
    Vector3 movement = _player.transform.rotation * movementInput;
    _characterController.SimpleMove(movement);
  }
}
