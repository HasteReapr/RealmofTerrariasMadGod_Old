﻿using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using ROTMG_Items.Dusts;

namespace ROTMG_Items.Items.Abilities.Projectiles
{
	public class GhostlyExplosion : ModProjectile
	{
		public override string Texture => "ROTMG_Items/Items/Abilities/Projectiles/SkullAOE";
		public override void SetDefaults()
		{
			projectile.damage = 1;
			projectile.width = 256;
			projectile.height = 256;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 4;
		}
		public override void AI()
		{
			projectile.velocity *= 0.01f;
		}
	}
}