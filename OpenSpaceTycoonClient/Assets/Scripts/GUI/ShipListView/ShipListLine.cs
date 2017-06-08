using UnityEngine;

public class ShipListLine : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI shipName = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI status = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI load = null;

    private OSTData.Ship _ship = null;

    public void SetShip(OSTData.Ship ship) {
        _ship = ship;
        shipName.text = "SHIP " + _ship.ID;
    }

    void Update() {
        if(null != _ship) {
            status.text = _ship.GetState();
            int total = 0;
            foreach(OSTData.ResourceElement.ResourceType t in System.Enum.GetValues(typeof(OSTData.ResourceElement.ResourceType))) {
                total += _ship.Cargo.GetResourceQte(t);
            }
            load.text = total + "m3";
        }
    }
}
