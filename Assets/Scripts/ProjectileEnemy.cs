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
        var collider = GetComponent<BoxCollider2D>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("SpecializedCollision");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
       
    }

}
