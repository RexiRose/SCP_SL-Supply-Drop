using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using InventorySystem.Items.Usables;
using MapGeneration.Distributors;
using MEC;
using PlayerRoles;
using PluginAPI.Events;
using Respawning;

namespace SupplyDrop
{
    internal class EventHandler
    {
        public class SupplyItem
        {
            public ItemType Type;
            public int Chance;
            public int Min;
            public int Max;

            public SupplyItem(ItemType type, int chance, int min, int max) 
            {
                Type = type;
                Chance = chance;
                Min = min;
                Max = max;
            }
        }

        private CoroutineHandle _timerHandle;

        public void OnStartedRound()
        {
            if (Round.IsStarted)
            {
                _timerHandle = Timing.RunCoroutine(CountdownCoroutine());
                Log.Info("Timer elindítva");

            }
        }

        public void OnRestartRound()
        {
            if (_timerHandle.IsRunning)
            {
                Timing.KillCoroutines(_timerHandle);
                Log.Info("Timer kitakarítva");
            }
        }
        private IEnumerator<float> CountdownCoroutine()
        {
            while (true)
            {
                int seconds = 400;
                while (seconds >= 0)
                {


                    int minutes = seconds / 60;
                    int remainingSeconds = seconds % 60;

                    string timeString = $"{minutes:00}:{remainingSeconds:00}";

                    foreach (var player in Player.List)
                    {
                        if (player.CurrentItem?.Type == ItemType.Radio)
                        {
                            player.ShowHint($"Hamarosan érkezők az ellátmány, visszaszámlálás: {timeString} perc", 1.2f);
                        }
                    }

                    yield return Timing.WaitForSeconds(1f);
                    seconds--;
                }

                yield return Timing.WaitForSeconds(25f);
                SpawnSupplayDrop();
                Map.Broadcast(10, "Az ellátmány megérkezet a felszínre.");
                Log.Info("A timer letelt, az ellátmány megérkezett");
                
            }

        }

        private void SpawnSupplayDrop()
        {
            UnityEngine.Vector3 Spawn = new UnityEngine.Vector3(115.429f, 295.461f, -43.153f);

            Log.Info("Supply Drop: Tárgyak generálása elkezdődött...");
            foreach (var Supply in Main.instance.Config.supplyItems)
            { 
                if (UnityEngine.Random.Range(1, 101) <= Supply.Chance)
                {
                    int amount = UnityEngine.Random.Range(Supply.Min, Supply.Max + 1);

                    for (int i = 0; i < amount; i++ )
                    {
                        var drop = Exiled.API.Features.Items.Item.Create(Supply.Type);
                        var pickup = drop.CreatePickup(Spawn);

                        UnityEngine.Vector3 randomspawn = new UnityEngine.Vector3(UnityEngine.Random.Range(-1.5f, 1.5f), 0.5f, UnityEngine.Random.Range(-1.5f, 1.5f)
                    );

                    pickup.Position += randomspawn;

                    }
                }
            }
            Log.Info("Supply Drop: Tárgyak generálása sikeres");

        }
    }
}