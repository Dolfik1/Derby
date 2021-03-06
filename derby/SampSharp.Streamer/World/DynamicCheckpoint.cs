﻿using System;
using System.Linq;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Natives;

namespace SampSharp.Streamer.World
{
    public class DynamicCheckpoint : DynamicWorldObject<DynamicCheckpoint>
    {
        public DynamicCheckpoint(int id)
        {
            Id = id;
        }

        public DynamicCheckpoint(Vector position, float size = 1.0f, int worldid = -1, int interiorid = -1,
            GtaPlayer player = null, float streamdistance = 100.0f)
        {
            Id = StreamerNative.CreateDynamicCP(position.X, position.Y, position.Z, size, worldid, interiorid,
                player == null ? -1 : player.Id, streamdistance);
        }

        public DynamicCheckpoint(Vector position, float size, float streamdistance, int[] worlds = null,
            int[] interiors = null,
            GtaPlayer[] players = null)
        {
            Id = StreamerNative.CreateDynamicCPEx(position.X, position.Y, position.Z, size, streamdistance, worlds,
                interiors,
                players == null ? null : players.Select(p => p.Id).ToArray());
        }

        public bool IsValid
        {
            get { return StreamerNative.IsValidDynamicCP(Id); }
        }

        public override StreamType StreamType
        {
            get { return StreamType.Checkpoint; }
        }

        public float Size
        {
            get { return GetFloat(StreamerDataType.Size); }
            set { SetFloat(StreamerDataType.Size, value); }
        }

        public event EventHandler<PlayerEventArgs> Enter;
        public event EventHandler<PlayerEventArgs> Leave;

        public void ToggleForPlayer(GtaPlayer player, bool toggle)
        {
            AssertNotDisposed();

            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            StreamerNative.TogglePlayerDynamicCP(player.Id, Id, toggle);
        }

        public bool IsPlayerInCheckpoint(GtaPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            return StreamerNative.IsPlayerInDynamicCP(player.Id, Id);
        }

        public static void ToggleAllForPlayer(GtaPlayer player, bool toggle)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            StreamerNative.TogglePlayerAllDynamicCPs(player.Id, toggle);
        }

        public static DynamicCheckpoint GetPlayerVisibleDynamicCheckpoint(GtaPlayer player)
        {
            int id = StreamerNative.GetPlayerVisibleDynamicCP(player.Id);

            return id < 0 ? null : FindOrCreate(id);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            StreamerNative.DestroyDynamicCP(Id);
        }

        public virtual void OnEnter(PlayerEventArgs e)
        {
            if (Enter != null)
                Enter(this, e);
        }

        public virtual void OnLeave(PlayerEventArgs e)
        {
            if (Leave != null)
                Leave(this, e);
        }
    }
}