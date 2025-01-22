using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private GarageController _garageController;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<GarageController>().FromInstance(_garageController).AsSingle();
        //Container.Bind<HandController>().AsSingle();
        //Container.Bind<MovementController>().AsSingle();
        //Container.Bind<ItemsSpawner>().AsSingle();
        //Container.Bind<TargetController>().AsSingle();
        //Container.Bind<InputController>();
    }
}