using ROTMG_Items.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ROTMG_Items.Items
{
	public class Covert_Shot : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.penetrate = 10;
			projectile.timeLeft = 60;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
			projectile.rotation = projectile.velocity.ToRotation();
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item1, projectile.position);
		}
	}
}