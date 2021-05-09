using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayTests
{
  public class a_moving_cube
  {
    [UnityTest]
    public IEnumerator moving_forward_changes_position() {
      // Arrange
      var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
      cube.transform.position = Vector3.zero;

      for (int i = 0; i < 10; i++) {
        // Act
        cube.transform.position += Vector3.forward;
        yield return null;

        // Assert
        Assert.AreEqual(i + 1, cube.transform.position.z);
      }
    }
  }
}
