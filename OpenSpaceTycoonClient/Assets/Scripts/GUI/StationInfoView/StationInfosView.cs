using UnityEngine;
using UnityEngine.UI;
using OSTData;

public class StationInfosView : MonoBehaviour {

    [SerializeField]
    private Text stationName = null;

    [SerializeField]
    private Text stationType = null;

    private Station _station = null;

    public void SetStation(Station station) {
        _station = station;
        UpdateView();
    }

    private void UpdateView() {
        if (null != _station) {
            stationName.text = _station.Name;
            stationType.text = _station.Type.ToString();
        }
    }
}