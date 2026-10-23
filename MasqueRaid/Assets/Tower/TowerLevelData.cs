using UnityEngine;

[System.Serializable]
public class TowerLevelData
{
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _fireRate;
    [SerializeField] private ResourceCost[] _upgradeCosts;

    public int Damage
    {
        get { return _damage; }
    }

    public float Range
    {
        get { return _range; }
    }
    public float FireRate
    {
        get { return _fireRate; }
    }
    public ResourceCost[] UpgradeCosts
    {
        get { return _upgradeCosts; }
    }
}