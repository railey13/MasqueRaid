using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public void ConsumeItem(ScriptableDrops item, int amount) {
        if (_inventory.ContainsKey(item)) {

            if (_inventory[item].GetAmount() < amount) return;

            _inventory[item].UpdateAmount(-amount);

            if (_inventory[item].GetAmount() <= 0) {
                _inventory.Remove(item);
            }
        }   
    }

}
