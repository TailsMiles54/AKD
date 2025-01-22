using DG.Tweening;
using UnityEngine;
using Zenject;

public class GarageController : MonoBehaviour, IInitializable
{
    [SerializeField] private Transform _garageDoor;
    [SerializeField] private Vector3 _garageDoorOpenPosition;
    [SerializeField] private Vector3 _garageDoorOpenRotation;

    public void Initialize()
    {
        OpenGarageDoor();
    }

    private void OpenGarageDoor()
    {
        _garageDoor.DOMove(_garageDoorOpenPosition, 1.5f);
        _garageDoor.DORotate(_garageDoorOpenRotation, 1.5f);
    }
}