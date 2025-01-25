using UnityEngine;
using System.Collections.Generic;

public class Player : Entity
{
    [Header("Player Stats")]
    [SerializeField] private int attackPower = 10; // Base attack power
    [SerializeField] private int defense = 5;      // Base defense
    [SerializeField] private int agility = 5;      // Base agility
    [SerializeField] private int stamina = 100;    // Player's current stamina
    [SerializeField] private int maxStamina = 100; // Maximum stamina
    [SerializeField] private float staminaRegenRate = 5f; // Stamina points regenerated per second

    private List<Item> inventory = new List<Item>(); // List of collected items

    // Calculate stats based on collected items
    public void CalculateStats()
    {
        int totalAttackBonus = 0;
        int totalDefenseBonus = 0;
        int totalAgilityBonus = 0;

        foreach (Item item in inventory)
        {
            totalAttackBonus += item.AttackBonus;
            totalDefenseBonus += item.DefenseBonus;
            totalAgilityBonus += item.AgilityBonus;
        }

        // Update stats with bonuses
        attackPower = 10 + totalAttackBonus;
        defense = 5 + totalDefenseBonus;
        agility = 5 + totalAgilityBonus;

        Debug.Log($"Updated Stats - Attack: {attackPower}, Defense: {defense}, Agility: {agility}");
    }

    // Add an item to the inventory and recalculate stats
    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
        Debug.Log($"Picked up item: {item.itemName}");
        CalculateStats();
    }

    // Consume stamina for actions
    public bool ConsumeStamina(float amount)
    {
        if (stamina >= amount)
        {
            stamina -= Mathf.RoundToInt(amount);
            Debug.Log($"Stamina consumed: {amount}. Remaining stamina: {stamina}");
            return true;
        }
        else
        {
            Debug.Log("Not enough stamina!");
            return false;
        }
    }

    // Regenerate stamina over time
    private void RegenerateStamina()
    {
        if (stamina < maxStamina)
        {
            stamina += Mathf.RoundToInt(staminaRegenRate * Time.deltaTime);
            stamina = Mathf.Min(stamina, maxStamina); // Clamp to max stamina
        }
    }

    // Handle player input and stamina regeneration
    protected override void Update()
    {
        base.Update();

        // Regenerate stamina every frame
        RegenerateStamina();

        // Sprint logic (consume stamina)
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) && movement != Vector3.zero && stamina > 0)
        {
            if (ConsumeStamina(10 * Time.deltaTime)) // Sprinting costs stamina
            {
                Move(movement * 2); // Double speed for sprinting
            }
        }
        else
        {
            Move(movement); // Normal movement
        }
    }
}
