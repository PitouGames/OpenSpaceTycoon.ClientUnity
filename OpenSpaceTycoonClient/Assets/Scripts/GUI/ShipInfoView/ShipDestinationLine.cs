using UnityEngine;

public class ShipDestinationLine : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI toText = null;

    [System.NonSerialized]
    private OSTData.ShipDestination _dest = null;

    public void SetDestination(OSTData.ShipDestination dest) {
        _dest = dest;

        toText.text = _dest.Destination.Name;
    }

    public void OnDeleteClic() {
        _dest.Ship.RemoveDestination(_dest);
    }
}