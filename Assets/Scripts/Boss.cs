using UnityEngine;

public class Boss : Entity
{
   [Header("Enemy Stats")]
    [SerializeField] private int baseDamage = 1; // Enemy's base damage
    [SerializeField] private int sightRange = 1; // Enemy's field of view
    [SerializeField] private int perception = 1; // Enemy's perception beyond sight range

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
}
