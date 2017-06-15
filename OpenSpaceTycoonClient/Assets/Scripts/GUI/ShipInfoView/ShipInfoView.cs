using UnityEngine;

public class ShipInfoView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI shipName = null;

    [SerializeField]
    private Transform destinationContent = null;

    [SerializeField]
    private ShipDestinationLine destLinePrefab = null;

    [System.NonSerialized]
    private OSTData.Ship _ship = null;

    public void SetShip(OSTData.Ship ship) {
        _ship = ship;

        _ship.onDestinationChange += UpdateDestinations;

        shipName.text = "ship " + _ship.ID.ToString();

        UpdateDestinations();
    }

    public void OnNewDestClic() {
        DataModel model = FindObjectOfType<DataModel>();
        _ship.AddDestination(model.Universe.GetStation(1));
    }

    private void OnDestroy() {
        _ship.onDestinationChange -= UpdateDestinations;
    }

    private void UpdateDestinations() {
        while (destinationContent.childCount > 0) {
            DestroyImmediate(destinationContent.GetChild(0).gameObject);
        }

        foreach (OSTData.ShipDestination d in _ship.GetDestinations()) {
            ShipDestinationLine line = Instantiate<ShipDestinationLine>(destLinePrefab);
            line.transform.SetParent(destinationContent);
            line.SetDestination(d);
            line.SetEditable(d != _ship.CurrentDestination);
        }
    }
}