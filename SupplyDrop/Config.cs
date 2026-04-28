using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using static SupplyDrop.EventHandler;

namespace SupplyDrop
{
    internal class Config : IConfig
    {
        [Description("Enable/Disable SuplayDrop")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enable/Disable Debug")]
        public bool Debug { get; set; } = false;

        [Description("List of supply items")]
        public List<SupplyItem> supplyItems { get; set; } = new List<SupplyItem>
        {
            new SupplyItem(ItemType.Medkit, 80, 2, 4),
            new SupplyItem(ItemType.Painkillers, 100, 2, 4),
            new SupplyItem(ItemType.Ammo556x45, 100, 3, 5),
            new SupplyItem(ItemType.Ammo9x19, 100, 3, 5),
            new SupplyItem(ItemType.Ammo762x39, 100, 3, 5),
            new SupplyItem(ItemType.GunCrossvec, 40, 1, 2),
            new SupplyItem(ItemType.MicroHID, 5, 1, 1),
            new SupplyItem(ItemType.ArmorLight,60, 1, 3),
            new SupplyItem(ItemType.ArmorCombat, 40, 1, 2),
            new SupplyItem(ItemType.KeycardMTFCaptain, 50, 1, 1),
            new SupplyItem(ItemType.KeycardFacilityManager, 10, 1, 1),
            new SupplyItem(ItemType.SCP1853, 20, 1, 1),
            new SupplyItem(ItemType.SCP207, 5, 1, 1),
            new SupplyItem(ItemType.GrenadeHE, 60, 1, 3),
            new SupplyItem(ItemType.GrenadeFlash, 70, 2, 3),
        };
    }

}
