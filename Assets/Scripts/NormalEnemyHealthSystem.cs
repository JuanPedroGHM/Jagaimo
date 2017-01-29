public class NormalEnemyHealthSystem : HealthSystem
{
    protected override void Die()
    {
        FindObjectOfType<SoundManager>().PlaySound("Enemy_Death");
        base.Die();
    }
}