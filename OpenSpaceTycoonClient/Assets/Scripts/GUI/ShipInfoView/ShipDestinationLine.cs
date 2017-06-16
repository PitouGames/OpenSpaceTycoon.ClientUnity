using System.Collections.Generic;

using UnityEngine;

public class ShipDestinationLine : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Dropdown drop = null;

    [SerializeField]
    private ShipLoadLine loadLinePrefab = null;

    [SerializeField]
    private Transform loadsContent = null;

    [SerializeField]
    private Transform unloadsContent = null;

    [System.NonSerialized]
    private OSTData.ShipDestination _dest = null;

    private void Awake() {
        drop.ClearOptions();
        DataModel model = FindObjectOfType<DataModel>();

        drop.onValueChanged.AddListener(OnDestChange);

        List<string> stationNames = new List<string>();
        foreach (OSTData.Station s in model.Universe.GetStations()) {
            stationNames.Add(s.Name);
        }
        drop.AddOptions(stationNames);
    }

    public void SetEditable(bool isEditable) {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.interactable = isEditable;
    }

    public void SetDestination(OSTData.ShipDestination dest) {
        _dest = dest;
        drop.value = _dest.Destination.ID - 1;

        foreach (OSTData.ShipDestination.LoadData l in _dest.Loads) {
            ShipLoadLine line = Instantiate<ShipLoadLine>(loadLinePrefab);
            line.transform.SetParent(loadsContent);
            line.Setdata(l);
        }

        foreach (OSTData.ShipDestination.LoadData l in _dest.Unloads) {
            ShipLoadLine line = Instantiate<ShipLoadLine>(loadLinePrefab);
            line.transform.SetParent(unloadsContent);
            line.Setdata(l);
        }
    }

    public void OnDeleteClic() {
        _dest.Ship.RemoveDestination(_dest);
    }

    private void OnDestChange(int value) {
        DataModel model = FindObjectOfType<DataModel>();
        _dest.ChangeDestination(model.Universe.GetStation(value + 1));
    }
}