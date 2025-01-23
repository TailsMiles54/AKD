using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Settings
{
    [Serializable]
    public class ItemsSettings
    {
        [field: SerializeField] public List<ItemSetting> Items { get; private set; }

        public List<ItemSetting> GetRandomItems(int count)
        {
            return Items.GetRandomElements(count);
        }
    }
}