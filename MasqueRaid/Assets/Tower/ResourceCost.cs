using UnityEngine;
[System.Serializable]
public class ResourceCost
{
   
        [SerializeField] private ScriptableDrops _material;
       [SerializeField] private int _amount;


    public int ResourceAmount
    {

        get { return _amount; }
    }

    public ScriptableDrops ResourceMaterial
    {
        get { return _material; }
    }

}
