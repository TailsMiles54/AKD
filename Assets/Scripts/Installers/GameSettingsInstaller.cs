using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private ItemsSettings _itemsSettings;
    
        public override void InstallBindings()
        {
            Container.BindInstances(_itemsSettings);
        }
    }
}