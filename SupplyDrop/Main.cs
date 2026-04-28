using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using PlayerRoles.Spectating;

namespace SupplyDrop
{
    internal class Main : Plugin<Config>
    {
        public override string Author { get; } = "RexiRose";
        public override string Name { get; } = "SuplayDrop";
        public override string Prefix { get; } = "SuplayDrop";
        public override Version Version => new Version(1, 0, 0);

        private EventHandler events;

        public static Main instance { get; private set;  }
        public override void OnEnabled()
        {
            instance = this;
            events = new EventHandler();
            Exiled.Events.Handlers.Server.RoundStarted += events.OnStartedRound;
            Exiled.Events.Handlers.Server.RestartingRound += events.OnRestartRound;

            base.OnEnabled();
        }
        public override void OnDisabled() 
        {
            instance = null;
            events = null;
            Exiled.Events.Handlers.Server.RoundStarted -= events.OnStartedRound;
            Exiled.Events.Handlers.Server.RestartingRound -= events.OnRestartRound;
            base.OnDisabled();
        }

    }

}
