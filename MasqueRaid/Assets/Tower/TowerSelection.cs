
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class TowerSelection : MonoBehaviour
{
    private Tower _selectedTower;
    [SerializeField] private GameObject _towerUpgradePanel;
    [SerializeField] private TextMeshProUGUI _towerInfo;
    private void Start()
    {
        _towerUpgradePanel.SetActive(false);
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPostion = Camera.main.ScreenToWorldPoint(mousePosition);
            CheckInteractable(worldPostion);
        }

        if (Keyboard.current.spaceKey.wasReleasedThisFrame) {
            CloseWindow();
        }
    }

    public void CheckInteractable(Vector2 worldPostion) {
        RaycastHit2D hit = Physics2D.Raycast(worldPostion, Vector2.zero);
        if (hit.collider != null) {
            Tower tower = hit.collider.transform.root.GetComponent<Tower>();
            if (tower != null) {
                Debug.Log("Text reference: " + _towerInfo);
                Debug.Log("Selected tower: " + _selectedTower);

                _selectedTower = tower;
                _towerInfo.text = "Tower - Lvl. " + _selectedTower.CurrentLevel;
                _towerUpgradePanel.SetActive(true);
                Debug.Log("Selected Tower: " + _selectedTower.name);

            }
        }
    }

    public void UpgradeSelectedTower()
    {
        if (_selectedTower != null)
        {
            _selectedTower.UpgradeTower();
            Debug.Log("Upgraded Tower: " + _selectedTower.name);
            _selectedTower = null;
           
        }
    }

    public void RepairSelectedTower() {
        if (_selectedTower != null) {
            //_selectedTower.RepairTower();
            Debug.Log("Repaired Tower: " + _selectedTower.name);
        }
    }

    public void CloseWindow() {
        _towerUpgradePanel.SetActive(false);
    }
}





