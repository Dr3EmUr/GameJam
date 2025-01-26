using UnityEngine;

public class ProjectileEnemy : Entity
{
    [Header("Enemy Stats")]
    public int IdealDistance = 2;
    public float cooldown = 2;
    public GameObject BulletModel;

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

    Player currentPlayer;

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        var plr = collision.GetComponent<Player>();

        if (plr != null)
            currentPlayer = plr;

    }

    void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        var plr = collision.GetComponent<Player>();

        if (plr != null)
            currentPlayer = null;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (currentPlayer != null)
        {
            var subtractionVector = currentPlayer.transform.position - transform.position;
            var distance = subtractionVector.magnitude;
            var plrDirection = subtractionVector.normalized;

            Debug.Log(distance);

            if (distance > IdealDistance)
            {
                Move(plrDirection * speed);
            }
            else
            {
                Move(-plrDirection * speed);
            }

            TryAttack(plrDirection);

        }
        
       
    }

    float lastAttackTime = 0;

    public bool TryAttack(Vector2 direction)
    {
        Debug.Log(Time.time);
        Debug.Log(lastAttackTime);
        if (Time.time >= lastAttackTime + cooldown)
        {
            PerformAttack(direction);
            lastAttackTime = Time.time; // Update the last attack time
            return true;
        }
        else
        {
            Debug.Log("Weapon is on cooldown!");
            return false;
        }

    }

    private void PerformAttack(Vector2 direction)
    {
        Debug.Log("Perform attack!");
        GameObject go = Instantiate(BulletModel);
        var bullet = go.GetComponent<Bullet>();

        bullet.BulletSetup(transform.position, direction, "Player");
    }

}
