using System.Collections.Generic;
using System.Linq;
using Zenject;

public class ItemsSpawner : IInitializable
{
    private List<StorageController> _storageControllers;
    private ItemsSettings _itemsSettings;
    
    public ItemsSpawner(List<StorageController> storageControllers, ItemsSettings itemsSettings)
    {
        _storageControllers = storageControllers.ThrowIfArgumentNull();
        _itemsSettings = itemsSettings.ThrowIfArgumentNull();
        
        SpawnItems();
    }

    private void SpawnItems()
    {
        foreach (var storageController in _storageControllers)
        {
            var spawnedElements = _itemsSettings.GetRandomItems(3);
            var spawnedPrefabs = spawnedElements.Select(x => x.Prefab).ToList();
            
            storageController.SpawnItems(spawnedPrefabs);
        }
    }

    public void Initialize()
    {
        
    }
}