﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using System;

namespace ROTMG_Items.Items.Weapons.Projectiles
{
	public class YellowMissle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 90;
		}

		public override void AI()
		{
			if (projectile.ai[1] == 0)
			{
				projectile.ai[1] = Main.rand.Next(2) + 1;
				if (projectile.ai[1] == 1)
				{
					projectile.velocity = projectile.velocity.RotatedBy(MathHelper.Pi / 8);
				}
				if (projectile.ai[1] == 2)
				{
					projectile.velocity = projectile.velocity.RotatedBy(-MathHelper.Pi / 8);
				}
			}
			if (projectile.ai[1] == 1)
			{
				projectile.velocity = projectile.velocity.RotatedBy(Math.Sin(1.4f) * -0.04f);
			}
			else
			{
				projectile.velocity = projectile.velocity.RotatedBy(Math.Sin(1.4f) * 0.04f);
			}
			projectile.rotation = projectile.velocity.ToRotation();

		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.25f;
		}
	}
}