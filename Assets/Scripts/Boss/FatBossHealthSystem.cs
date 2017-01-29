public class FatBossHealthSystem : HealthSystem
{

    public Corpse corpse;



    protected override void Die()
    {
        var fatCorpse=  Instantiate(corpse, transform.position, transform.rotation);
        base.Die();
    }
}