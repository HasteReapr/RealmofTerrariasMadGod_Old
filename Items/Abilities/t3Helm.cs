﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
    public class t3Helm : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Helmet");
            Tooltip.SetDefault("A helmet made of solid lead it feels like it's crushing your spine...");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            AncientCost = 30;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<Buffs.Speedy>();
            item.buffTime = 540;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.WarrBuff>(), 540, false);
            for (int i = 0; i < Main.maxPlayers; i++)
                if (Main.player[i].active && Main.player[i].team == player.team && player.team != 0)
                {
                    Main.player[i].AddBuff(ModContent.BuffType<Buffs.WarrBuff>(), 540, false);
                }
            return true;
        }
    }
}