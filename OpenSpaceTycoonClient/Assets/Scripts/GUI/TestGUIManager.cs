using UnityEngine;

public class TestGUIManager : MonoBehaviour {
    private WindowSystem winSystem = null;

    [SerializeField]
    private MapView mapViewPrefab = null;

    private void Start() {
        winSystem = FindObjectOfType<WindowSystem>();
    }

    public void CreateEmpty() {
        winSystem.NewWindow("name", null);
    }

    public void CreateStationView(Object obj) {
        GameObject newObj = Instantiate(obj) as GameObject;
        Window window = winSystem.NewWindow("name", newObj);
        window.Title = "Station info";
    }

    public void CreateMapView() {
        MapView newObj = Instantiate<MapView>(mapViewPrefab);
        Window window = winSystem.NewWindow("MapView", newObj.gameObject);
        window.Title = "Map view";
    }
}