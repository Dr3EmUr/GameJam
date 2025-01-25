using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] public int baseDamage = 10; // Base damage of the bullet
    [SerializeField] public int damageVariation = 5; // Random variation added to the base damage
    private int damage; // Actual damage of this bullet

    [SerializeField] private float speed = 10f; // Bullet speed
    [SerializeField] private float lifespan = 5f; // How long the bullet exists before being destroyed

    public Vector2 currentDirection = Vector2.zero;
    
    public Weapon weapon;
    public Player player;

    void Start()
    {
        
        // Assign a random damage value around the base damage with variation
        damage = baseDamage + Random.Range(-damageVariation, damageVariation + 1);
        
        // Ensure damage is not negative
        damage = Mathf.Max(0, damage);
        
        damage = weapon.GetDameage();
        
        // Destroy the bullet after its lifespan expires
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Move the bullet forward at a constant speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Handle collision with other objects
    private void OnTriggerEnter(Collider other)
    {
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
    private void EntityBullet(){
        transform.position = player.transform.position;
        currentDirection = Input.mousePosition - Input.mousePosition;
    }
}
