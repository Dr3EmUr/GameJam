using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    [Header("Item Stats")]
    public string itemName;
    public int AttackBonus = 0; // Bonus to attack power
    public int DefenseBonus = 0; // Bonus to defense
    public int AgilityBonus = 0; // Bonus to agility
    public int StaminaBonus = 0; // Bonus to max stamina
}
