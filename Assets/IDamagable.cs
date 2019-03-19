public interface IDamagable
{
	bool Dead { get; }
	float Health { get; }
	void TakeDamage(float damage);
}
