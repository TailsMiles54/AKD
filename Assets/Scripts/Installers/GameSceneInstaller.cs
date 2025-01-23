using System.Collections.Generic;
using Character;
using Environment;
using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
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
            Container.BindInterfacesAndSelfTo<ItemsSpawner>().AsSingle();
        
            foreach (var storageController in _storageControllers)
            {
                Container.Bind<StorageController>().FromInstance(storageController).AsTransient();
            }
        }
    }
}