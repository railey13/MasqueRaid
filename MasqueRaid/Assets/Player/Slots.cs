using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour  {
    [SerializeField] private int _itemAmount;

    [SerializeField] private Image _itemIcon;
    [SerializeField] private Text _amountText;
    [SerializeField] private ScriptableDrops _droppedMaterial;

    public int GetAmount() {
        return _itemAmount;
    }

    public bool HasItem() {
        return _droppedMaterial != null;
    }
 
    public void SetItem(ScriptableDrops droppedMaterial, int amount) {
        this._droppedMaterial = droppedMaterial;
        _itemAmount = amount;
        _itemIcon.enabled = true;
        _amountText.enabled = true;

        UpdateSlot();
    }

    public void UpdateAmount(int amount) {
        _itemAmount += amount;

        if (_itemAmount <= 0) {
            _droppedMaterial = null;
            _itemAmount = 0;
        }

        UpdateSlot();
    }

    private void UpdateSlot() {
        if (_droppedMaterial) {
            _itemIcon.enabled = true;
            _amountText.enabled = true;
            _itemIcon.sprite = _droppedMaterial._sprite;
            _amountText.text = "x" + _itemAmount.ToString();
        }
        else {
            _itemIcon.enabled = false;
            _amountText.enabled = false;
        }
    }

}
