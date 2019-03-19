using UnityEngine;

public class Pistol : Gun
{
	public override bool Shoot()
	{
		if (base.Shoot())
		{
			StartProjectile();
			return true;
		}
		return false;
	}
}
