using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
  public class Test01
  {
    // A Test behaves as an ordinary method
    [Test]
    public void Test01SimplePasses() {
      // Arrange
      List<string> myStrings = new List<string>();

      // Act
      myStrings.Add("test");

      // Assert
      Assert.AreEqual(1, myStrings.Count);
    }
  }
}
