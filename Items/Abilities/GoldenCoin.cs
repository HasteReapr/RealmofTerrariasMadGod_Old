﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items.Abilities
{
	public class GoldenCoin : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			Main.projFrames[projectile.type] = 6;
		}
        public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 32;
			projectile.penetrate = -1;
		}

		public float Timer = 60;
		public float StartTimer = 60;
		public override void AI()
		{
			Main.player[projectile.owner].tankPet = projectile.whoAmI;
			Main.player[projectile.owner].tankPetReset = false;
			projectile.velocity *= 0.01f;
			if (projectile.ai[1] == 0)
			{
				StartTimer--;
				if (StartTimer == 0)
				{
					projectile.ai[1] = Main.rand.Next(2) + 1;
				}
			}
			if (projectile.ai[1] == 1)
			{
				Timer--;
				if (Timer == 0)
				{
					projectile.ai[1] = 3;
					Timer = 60;
				}
			}
			if (projectile.ai[1] == 2)
			{
				projectile.Kill();
			}
			if (projectile.ai[1] == 3)
            {
				projectile.ai[1] = Main.rand.Next(2) + 1;
            }

			if (++projectile.frameCounter >= 10)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
		}



		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
			Projectile.NewProjectile(projectile.position.X+16f, projectile.position.Y+16f, 0f, 0f, mod.ProjectileType("SilverCoin"), 0, 0f, projectile.owner, 0f, 0f);
		}
	}
}