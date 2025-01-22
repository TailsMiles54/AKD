using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private ItemsSettings _itemsSettings;
    
    public override void InstallBindings()
    {
        Container.BindInstances(_itemsSettings);
    }
}

[Serializable]
public class ItemsSettings
{
    [field: SerializeField] public List<ItemSetting> Items { get; private set; }

    public List<ItemSetting> GetRandomItems(int count)
    {
        return Items.GetRandomElements(count);
    }
}

[Serializable]
public class ItemSetting
{
    [field: SerializeField] public GameObject Prefab { get; private set; } 
}