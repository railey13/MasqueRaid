
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class TowerSelection : MonoBehaviour
{
    private Tower _selectedTower;
    [SerializeField] private GameObject _towerupgradePanel;
    [SerializeField] private TextMeshProUGUI _currentLevelText;
    private void Start()
    {
        _towerupgradePanel.SetActive(false);
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 worldPostion = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPostion, Vector2.zero);
            if(hit.collider != null)
            {
                Tower tower = hit.collider.transform.root.GetComponent<Tower>();
                if (tower != null)
                {
                  //  _currentLevelText.text = "Level: " + _selectedTower.CurrentLevel;
                    _selectedTower = tower;
                    _towerupgradePanel.SetActive(true);
                    Debug.Log("Selected Tower: " + _selectedTower.name);

                }
                else
                {
                    Debug.Log("Collider found, but no Tower component in parent!");
                }
            }
            else
            {
                Debug.Log("Nothing hit!");
            }
        }
        }


    public void UpgradeSelectedTower()
    {
        if (_selectedTower != null)
        {
            _selectedTower.UpgradeTower();
            Debug.Log("Upgraded Tower: " + _selectedTower.name);
        }
        else
        {
            Debug.Log("No tower selected to upgrade.");
        }
    }
    }





