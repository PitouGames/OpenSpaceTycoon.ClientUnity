using UnityEngine;

public class StationList : MonoBehaviour {

    [SerializeField]
    private StationListLine stationListLinePrefab = null;

    [SerializeField]
    private Transform content = null;

    public void SetUniverse(OSTData.Universe universe) {
        foreach (OSTData.Station s in universe.GetStations()) {
            StationListLine line = Instantiate<StationListLine>(stationListLinePrefab);
            line.transform.SetParent(content);
            line.SetStation(s);
        }
    }
}