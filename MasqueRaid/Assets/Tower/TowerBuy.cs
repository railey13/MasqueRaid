using System.Security.Cryptography;
using UnityEngine;

public class TowerBuy : MonoBehaviour {
    [SerializeField] private Transform _towerSpawnLocation;
    [SerializeField] private TowerData _tower1;
    [SerializeField] private TowerData _tower2;

    public void BuildTower1() {
        if (Inventory.Instance.HasEnoughResources(_tower1.ConstructionCosts)) {
            Inventory.Instance.ConsumeItem(_tower1.ConstructionCosts[0].ResourceMaterial, _tower1.ConstructionCosts[0].ResourceAmount);
            Instantiate(_tower1.TowerPrefab, _towerSpawnLocation.position, Quaternion.identity);
        }
    }

    public void BuildTower2() {
        if (Inventory.Instance.HasEnoughResources(_tower2.ConstructionCosts)) {
            Inventory.Instance.ConsumeItem(_tower2.ConstructionCosts[0].ResourceMaterial, _tower2.ConstructionCosts[0].ResourceAmount);
            Instantiate(_tower2.TowerPrefab, _towerSpawnLocation.position, Quaternion.identity);
        }
    }

}
