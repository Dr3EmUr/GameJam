using UnityEngine;

public class ProjectileEnemy : Entity
{
    [Header("Enemy Stats")]
    public int PerceptionRange = 50;
    public int ShootingRange = 40;
    public int RunningRange = 20;

    // Method to attack the player
    public void AttackPlayer(Entity player)
    {
        if (!isAlive) return;

        player.TakeDamage(baseDamage);
        Debug.Log($"Enemy {gameObject.name} dealt {baseDamage} damage to the player.");
    }

    // Specific logic for enemy death
    protected override void Die()
    {
        base.Die();
        Debug.Log($"{gameObject.name} has been defeated.");
    }

    protected override void Start()
    {
        base.Start();
        GameObject playerObject = GameObject.Find("Player");
        Player player = playerObject.GetComponent<Player>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
       
    }

}
