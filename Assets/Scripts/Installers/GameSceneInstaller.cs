using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private GarageController _garageController;
    [SerializeField] private List<StorageController> _storageControllers;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GarageController>().FromInstance(_garageController).AsSingle();
        //Container.Bind<HandController>().AsSingle();
        //Container.Bind<MovementController>().AsSingle();
        Container.BindInterfacesAndSelfTo<ItemsSpawner>().AsSingle();
        //Container.Bind<TargetController>().AsSingle();
        //Container.Bind<InputController>();
        
        foreach (var storageController in _storageControllers)
        {
            Container.Bind<StorageController>().FromInstance(storageController).AsTransient();
        }
    }
}