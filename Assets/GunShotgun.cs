using UnityEngine;

public class GunShotgun : Gun
{
	[SerializeField]
	private int projectileAmount = 3;

	public override bool Shoot()
	{
		if (base.Shoot())
		{
			float spreadStep = inaccuracy / projectileAmount;
			for (int i = 0; i < projectileAmount; i++)
			{
				Quaternion bulletRot = Quaternion.Euler(0, Random.Range(-spreadStep, spreadStep), 0);
				StartProjectile(bulletRot);
			}
			return true;
		}
		return false;
	}
}
