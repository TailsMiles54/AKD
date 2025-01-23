using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private GarageController _garageController;
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private List<StorageController> _storageControllers;
    [SerializeField] private MovementController _movementController;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GarageController>().FromInstance(_garageController).AsSingle();
        Container.Bind<JoystickController>().FromInstance(_joystickController).AsSingle();
        Container.Bind<MovementController>().FromInstance(_movementController).AsSingle();
        //Container.Bind<HandController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemsSpawner>().AsSingle();
        //Container.Bind<TargetController>().AsSingle();
        //Container.Bind<InputController>();
        
        foreach (var storageController in _storageControllers)
        {
            Container.Bind<StorageController>().FromInstance(storageController).AsTransient();
        }
    }
}