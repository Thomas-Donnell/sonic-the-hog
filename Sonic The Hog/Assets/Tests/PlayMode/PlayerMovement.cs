using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using Scripts.PlayerMovement;

[TestFixture]
public class PlayerMovementTests
{
    private PlayerMovement playerMovement;
    private GameObject playerGameObject;



    [UnityTest]
    public IEnumerator PlayerFlipsWhenTurningAround()
    {
        playerGameObject = new GameObject();
        playerMovement = playerGameObject.AddComponent<PlayerMovement>();
        CallPrivateMethod(playerMovement, "Start"); // Equivalent to Start method in MonoBehaviour
        CallPrivateMethod(playerMovement, "Update");

        Assert.IsTrue(GetPrivateField<bool>(playerMovement, "isFacingRight"));
        yield return null;
    }

    private T GetPrivateField<T>(object obj, string fieldName)
    {
        FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        return (T)field.GetValue(obj);
    }

    // Helper method to call a private method
    private void CallPrivateMethod(object obj, string methodName)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        method.Invoke(obj, null);
    }

}