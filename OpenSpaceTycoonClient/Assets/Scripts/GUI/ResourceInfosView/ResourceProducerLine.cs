using UnityEngine;

public class ResourceProducerLine : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI name = null;

    private OSTData.Station _station = null;

    public void SetStation(OSTData.Station station) {
        _station = station;
        name.text = station.Name;
    }

    public void OnClic() {
        TestGUIManager manager = FindObjectOfType<TestGUIManager>();
        manager.CreateStationView(_station.ID);
    }
}