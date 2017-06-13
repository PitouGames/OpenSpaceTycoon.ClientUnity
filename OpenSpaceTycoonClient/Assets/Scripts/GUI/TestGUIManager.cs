using UnityEngine;
using UnityEngine.UI;

public class TestGUIManager : MonoBehaviour {
    private WindowSystem winSystem = null;

    [SerializeField]
    private MapView mapViewPrefab = null;

    [SerializeField]
    private StationList stationListPrefab = null;

    [SerializeField]
    private StationInfosView stationViewPrefab = null;

    [SerializeField]
    private ResourceHolderView resourceHolderViewPrefab = null;

    [SerializeField]
    private HangarListView hangarListPrefab = null;

    [SerializeField]
    private HangarView hangarViewPrefab = null;

    [SerializeField]
    private ShipListView shipListViewPrefab = null;

    [SerializeField]
    private ResourceListView resourceListViewPrefab = null;

    [SerializeField]
    private ResourceInfosView resourceInfoViewPrefab = null;

    [SerializeField]
    private ShipInfoView shipInfoViewPrefab = null;

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

    public void CreateMyHangarsView() {
        HangarListView newObj = Instantiate<HangarListView>(hangarListPrefab);
        Window window = winSystem.NewWindow("HangarList", newObj.gameObject);
        window.Title = "Hangar list";
        newObj.SetUniverse(dataModel.Universe);
    }

    public void CreateHangarView(OSTData.Hangar h) {
        HangarView newObj = Instantiate<HangarView>(hangarViewPrefab);
        Window window = winSystem.NewWindow("HangarView", newObj.gameObject);
        window.Title = "Hangar " + h.Station.Name;
        newObj.SetHangar(h);
    }

    public void CreateMyShipListView() {
        ShipListView newObj = Instantiate<ShipListView>(shipListViewPrefab);
        Window window = winSystem.NewWindow("ShipList", newObj.gameObject);
        window.Title = "My ships";
        newObj.SetUniverse(dataModel.Universe);
    }

    public void CreateShipInfoView(OSTData.Ship ship) {
        ShipInfoView view = Instantiate<ShipInfoView>(shipInfoViewPrefab);
        Window window = winSystem.NewWindow("ship info", view.gameObject);
        window.Title = "Ship " + ship.ID;
        view.SetShip(ship);
    }

    public void CreateResourceListView() {
        ResourceListView newObj = Instantiate<ResourceListView>(resourceListViewPrefab);
        Window window = winSystem.NewWindow("ResourceList", newObj.gameObject);
        window.Title = "resources list";
    }

    public void CreateResourceInfoView(OSTData.ResourceElement.ResourceType t) {
        ResourceInfosView newObj = Instantiate<ResourceInfosView>(resourceInfoViewPrefab);
        Window window = winSystem.NewWindow("Resource Info", newObj.gameObject);
        window.Title = "resource info";
        newObj.SetData(t);
    }

    public void LoadZone(InputField field) {
        int zone = 1;
        if (field.text != "") {
            zone = int.Parse(field.text);
        }
        TransitionManager manager = GameObject.FindObjectOfType<TransitionManager>();
        manager.LoadNewStationZone(zone);
    }

    public void StationHangar() {
        ResourceHolderView newObj = Instantiate<ResourceHolderView>(resourceHolderViewPrefab);
        Window window = winSystem.NewWindow("stationHangar", newObj.gameObject);
        window.Title = "Station hangar";
        newObj.SetZone(dataModel.Universe.GetStation(1).GetHangar(-1));
    }
}