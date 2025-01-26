using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] public int baseDamage = 10; // Base damage of the bullet
    [SerializeField] public int damageVariation = 5; // Random variation added to the base damage
    private int damage; // Actual damage of this bullet
    public string targetTag;

    [SerializeField] private float speed = 10f; // Bullet speed
    [SerializeField] private float lifespan = 5f; // How long the bullet exists before being destroyed

    public Vector2 currentDirection = Vector2.zero;    
    void Start()
    {        
        // Assign a random damage value around the base damage with variation
        damage = baseDamage + Random.Range(-damageVariation, damageVariation + 1);
        
        // Ensure damage is not negative
        damage = Mathf.Max(0, damage);
        
        
        // Destroy the bullet after its lifespan expires
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Move the bullet forward at a constant speed
        transform.Translate(currentDirection * speed * Time.deltaTime);
    }

    // Handle collision with other objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != targetTag)
            return;

        if (other.GetComponent<Entity>() == null)
            return;

        Debug.Log("BULLET HIT");

        Debug.Log("BULLET");
        // Check if the bullet hits an object with health
        Entity entity = other.GetComponent<Entity>();
        if (entity != null)
        {
            entity.TakeDamage(damage); // Apply damage to the entity
            Debug.Log($"Bullet hit {other.name} for {damage} damage.");
        }
        
        // Destroy the bullet on impact
        Destroy(gameObject);
    }

    public void BulletSetup(Vector3 StartingPos, Vector3 Direction, string TargetTag)
    {
        this.transform.position = StartingPos;
        currentDirection = Direction;
        this.targetTag = TargetTag;
    }
}
