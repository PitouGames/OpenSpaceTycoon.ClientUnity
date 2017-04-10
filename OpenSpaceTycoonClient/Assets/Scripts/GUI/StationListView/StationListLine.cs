using UnityEngine;
using UnityEngine.UI;

public class StationListLine : MonoBehaviour {

    [SerializeField]
    private Text stationName = null;

    private OSTData.Station _station = null;

    public void SetStation(OSTData.Station station) {
        _station = station;
        stationName.text = station.Name;
    }

    public void OnClic() {
        TestGUIManager test = GetComponentInParent<TestGUIManager>();
        test.CreateStationView(_station.ID);
    }
}