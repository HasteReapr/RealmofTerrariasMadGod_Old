﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.DataStructures;

//This ModPlayer is supposed to handle all of the pets.
namespace ROTMG_Items
{
    class PetPlayer : ModPlayer
    {
        public bool SpritePet;
        public bool Stonepet;
        public bool SupporterPet;

        public override void ResetEffects()
        {
            SpritePet = false;
            Stonepet = false;
            SupporterPet = false;
        }

        internal enum SyncPlayerMessage : byte
        {
            Pets,
            SpritePet,
            Stonepet,
            SupporterPet,
        }
        internal enum ROTMGModMessageType : byte
        {
            ROTMGPlayerSyncPlayer,
            SyncPlayerMessage,
            NonStopPartyChanged,
            AbilityPowerMax,
            AbilityPowerMax2,
            AbilityPowerRegen,
            AbilityPowerRegenTimer,
            AbilityPowerRegenRate,
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)ROTMGModMessageType.ROTMGPlayerSyncPlayer);
            packet.Write((byte)SyncPlayerMessage.Pets);
            packet.Write((byte)player.whoAmI);
            packet.Write(SpritePet);
            packet.Send(toWho, fromWho);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"SpritePet", SpritePet},
                {"StonePet", Stonepet },
                {"SupporterPet", SupporterPet},
            };
        }

        public override void Load(TagCompound tag)
        {
            SpritePet = tag.GetBool("SpritePet");
            Stonepet = tag.GetBool("Stonepet");
            SupporterPet = tag.GetBool("SupporterPet");
        }
    }
}
