using UnityEngine;

public class GunSingle : Gun
{
	public override bool Shoot()
	{
		if (base.Shoot())
		{
			StartProjectile(Quaternion.identity);
			return true;
		}
		return false;
	}
}
