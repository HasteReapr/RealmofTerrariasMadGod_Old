﻿using Terraria;
using Terraria.ModLoader;
using ROTMG_Items.Items.Pets;

namespace ROTMG_Items.Buffs.Pets
{
	public class ScaryBuff : ModBuff
	{
		public override void SetDefaults()
		{
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Spooky Boi");
			Description.SetDefault("\"Don't get sat on!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<ROTMGPlayer>().SpookyPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SpookyPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<SpookyPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}