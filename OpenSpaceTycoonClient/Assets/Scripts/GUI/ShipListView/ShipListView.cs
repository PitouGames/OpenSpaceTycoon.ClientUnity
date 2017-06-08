using UnityEngine;

public class ShipListView : MonoBehaviour {

    [SerializeField]
    ShipListLine linePrefab = null;

    [SerializeField]
    Transform content = null;

    private OSTData.Universe _universe = null;

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;

        foreach(OSTData.Ship s in universe.Ships) {
            ShipListLine line = Instantiate<ShipListLine>(linePrefab);
            line.transform.SetParent(content);
            line.SetShip(s);
        }
    }
}
