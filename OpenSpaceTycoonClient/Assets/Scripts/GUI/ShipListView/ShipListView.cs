using UnityEngine;

public class ShipListView : MonoBehaviour {

    [SerializeField]
    private ShipListLine linePrefab = null;

    [SerializeField]
    private Transform content = null;

    [System.NonSerialized]
    private OSTData.Universe _universe = null;

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;

        foreach (OSTData.Ship s in _universe.Ships) {
            ShipListLine line = Instantiate<ShipListLine>(linePrefab);
            line.transform.SetParent(content);
            line.SetShip(s);
        }
    }
}