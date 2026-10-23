using UnityEngine;
[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
public class TowerData : ScriptableObject
{
    [SerializeField] private ResourceCost[] _constructionCosts;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private TowerLevelData[] _towerLevels;


    public ResourceCost[] ConstructionCosts
    {
        get { return _constructionCosts; }
    }
    public GameObject TowerPrefab
    {
        get { return _towerPrefab; }
    }
    public TowerLevelData[] TowerLevels
    {
        get { return _towerLevels; }
    }


}
