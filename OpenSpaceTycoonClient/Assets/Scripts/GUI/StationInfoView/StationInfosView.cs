using UnityEngine;
using UnityEngine.UI;
using OSTData;

public class StationInfosView : MonoBehaviour {

    [SerializeField]
    private Text stationName = null;

    private Station _Station = null;

    public void SetStation(Station station) {
        _Station = station;
        stationName.text = station.Name;
    }
}