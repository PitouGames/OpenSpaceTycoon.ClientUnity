using UnityEngine;

public class TestGUIManager : MonoBehaviour {
    private WindowSystem winSystem = null;

    [SerializeField]
    private MapView mapViewPrefab = null;

    [SerializeField]
    private StationList stationListPrefab = null;

    [SerializeField]
    private StationInfosView stationViewPrefab = null;

    private DataModel dataModel = null;

    private void Start() {
        winSystem = FindObjectOfType<WindowSystem>();
        dataModel = FindObjectOfType<DataModel>();
    }

    public void CreateEmpty() {
        winSystem.NewWindow("name", null);
    }

    public void CreateStationView(int stationID) {
        StationInfosView newObj = Instantiate<StationInfosView>(stationViewPrefab);
        Window window = winSystem.NewWindow("name", newObj.gameObject);
        window.Title = "Station info";
        foreach (OSTData.Station s in dataModel.Universe.GetStations()) {
            if (s.ID == stationID) {
                newObj.SetStation(s);
                return;
            }
        }
    }

    public void CreateMapView() {
        MapView newObj = Instantiate<MapView>(mapViewPrefab);
        Window window = winSystem.NewWindow("MapView", newObj.gameObject);
        window.Title = "Map view";
        newObj.SetUniverse(dataModel.Universe);
    }

    public void CreateStationListView() {
        StationList newObj = Instantiate<StationList>(stationListPrefab);
        Window window = winSystem.NewWindow("StationList", newObj.gameObject);
        window.Title = "Station list";
        newObj.SetUniverse(dataModel.Universe);
    }
}