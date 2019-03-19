using UnityEngine;

public class Shotgun : Gun
{
	[SerializeField]
	private int projectileAmount = 3;

	public override bool Shoot()
	{
		if (base.Shoot())
		{
			for (int i = 0; i < projectileAmount; i++)
			{
				StartProjectile();
			}
			return true;
		}
		return false;
	}
}
