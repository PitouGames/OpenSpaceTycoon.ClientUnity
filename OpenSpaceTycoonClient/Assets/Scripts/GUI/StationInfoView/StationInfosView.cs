using UnityEngine;
using UnityEngine.UI;
using OSTData;

public class StationInfosView : MonoBehaviour {

    [SerializeField]
    private Text stationName = null;

    private Station _Station = null;

    private void Awake() {
        _Station = new Station(Station.StationType.Agricultural, null, new OSTTools.Vector3D());
        stationName.text = _Station.Name;
    }

    private void Update() {
    }
}