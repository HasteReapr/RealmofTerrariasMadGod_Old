﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Buffs;
using ROTMG_Items.Items.Materials;

namespace ROTMG_Items.Items.Abilities
{
    public class BloodySurprises : AncientCostFunction
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloak of Bloody Surprises");
            Tooltip.SetDefault("This cloak was made for the lunar assassins to kill the Moon Lord by themselves.\nThere was only enough material for one, and he failed.\nWhile invisible, no enemies will target you.\nMakes you invisibile, slows you and adds 25 attack.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            AncientCost = 20;
            item.rare = ItemRarityID.Expert;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = ModContent.BuffType<RogueInvisible>();
            item.buffTime = 1200;
            buffType2 = ModContent.BuffType<ATKUp>();
            buffTime2 = 1440;
            buffType3 = ModContent.BuffType<Slowed>();
            buffTime3 = 1440;
            isAbility = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(buffType2, buffTime2, false);
            player.AddBuff(buffType3, buffTime3, false);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LunarEssence>(), 12);
            recipe.AddIngredient(ModContent.ItemType<t6Cloak>());
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}