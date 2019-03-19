using UnityEngine;

public class Machinegun : Gun
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
