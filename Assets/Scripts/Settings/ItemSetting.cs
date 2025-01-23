using System;
using UnityEngine;

namespace Settings
{
    [Serializable]
    public class ItemSetting
    {
        [field: SerializeField] public GameObject Prefab { get; private set; } 
    }
}