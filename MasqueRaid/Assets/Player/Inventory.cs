using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour {
    public static Inventory Instance = null;

    [Header("Attributes")]
    [SerializeField] private List<Slots> _slots = new List<Slots>();
    
    private Dictionary<ScriptableDrops, Slots> _inventory = new Dictionary<ScriptableDrops, Slots>();   
    public Dictionary<ScriptableDrops, Slots> InventoryDictionary { get { return _inventory; } }

    public void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void AddItem(ScriptableDrops item, int amount) {
        if (_inventory.ContainsKey(item)) {
            _inventory[item].UpdateAmount(amount);
            return;
        }

        foreach (Slots slot in _slots) {
            if (!slot.HasItem()) {
                slot.SetItem(item, amount);
                _inventory[item] = slot;
                break;
            }
        }
    }

    public bool HasEnoughResources(ResourceCost[] costs)
    {
        foreach (ResourceCost cost in costs)
        {
            ScriptableDrops item = cost.ResourceMaterial;
            int requiredAmount = cost.ResourceAmount;

            if (!_inventory.ContainsKey(item))
            {
                return false;
            }

            if (_inventory[item].GetAmount() < requiredAmount)
            {
                return false;
            }
        }

        return true;
    }
    public void ConsumeItem(ScriptableDrops item, int amount) {
        if (_inventory.ContainsKey(item)) {

            if (_inventory[item].GetAmount() < amount) return;

            _inventory[item].UpdateAmount(-amount);

            if (_inventory[item].GetAmount() <= 0) {
                _inventory.Remove(item);
            }
        }   
    }

    // for testing purposes and mainly for the prevention of lets say 
    // payer may have wood but no stone and the player may want to build a
    // tower that requires both wood and stone, this function will check if the player has enough resources to build the tower
    public bool ConsumeResources(ResourceCost[] costs)
    {
        if (!HasEnoughResources(costs))
        {
            return false;
        }

        foreach (ResourceCost cost in costs)
        {
            ScriptableDrops item = cost.ResourceMaterial;
            int amount = cost.ResourceAmount;

            ConsumeItem(item, amount);
        }

        return true;
    }

}
