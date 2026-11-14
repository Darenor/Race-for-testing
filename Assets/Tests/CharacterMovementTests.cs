using NUnit.Framework;
using UnityEngine;

public class CharacterMovementTests
{
    private GameObject carObject;
    private NetworkCarController car;

    [SetUp]
    public void SetUp()
    {
        carObject = new GameObject("TestCar");
        car = carObject.AddComponent<NetworkCarController>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(carObject);
    }

    // Тест 1: автомобиль движется вперед
    [Test]
    public void CarMovesForward()
    {
        car.ApplyMovement(1f, 0f);

        Assert.Greater(
            carObject.transform.position.z,
            0f,
            "Car should move forward"
            );
    }

    // Тест 2: автомобиль движется назад
    [Test]
    public void CarMovesBackward()
    {
        car.ApplyMovement(-1f, 0f);

        Assert.Less(
            carObject.transform.position.z,
            0f,
            "Car should move backward"
            );
    }

    // Тест 3: без ввода автомобиль не движется
    [Test]
    public void CarDoesNotMoveWithoutInput()
    {
        Vector3 startPosition = carObject.transform.position;

        car.ApplyMovement(0f, 0f);

        Assert.AreEqual(
            startPosition,
            carObject.transform.position,
            "Car should stay in place without input"
            );
    }

    // Тест 4: управление поворачивает автомобиль
    [Test]
    public void CarTurnsWhenSteeringInputIsApplied()
    {
        float startRotation = carObject.transform.eulerAngles.y;

        car.ApplyMovement(1f, 1f);

        float endRotation = carObject.transform.eulerAngles.y;

        Assert.Greater(
            endRotation,
            startRotation,
            "Car should turn when steering input is applied"
            );
    }
}
