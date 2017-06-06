using UnityEngine;
using UnityEngine.UI;
using OSTData;

public class StationInfosView : MonoBehaviour {

    [SerializeField]
    private Text stationName = null;

    [SerializeField]
    private Text stationType = null;

    [SerializeField]
    private ResourceHolderView hangarView = null;

    private Station _station = null;

    public void SetStation(Station station) {
        _station = station;
        hangarView.SetZone(station.GetHangar(-1));

        UpdateView();
    }

    private void UpdateView() {
        if (null != _station) {
            stationName.text = _station.Name;
            stationType.text = _station.Type.ToString();
        }
    }
}