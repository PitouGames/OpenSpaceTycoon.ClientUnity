using UnityEngine;

public class ResourceProducerLine : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI nameTxt = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI priceTxt = null;

    [System.NonSerialized]
    private OSTData.Station _station = null;

    public void SetStation(OSTData.Station station) {
        _station = station;
        nameTxt.text = station.Name;
        priceTxt.text = "";
    }

    public void SetPrice(int price) {
        priceTxt.text = price.ToString() + "ICU";
    }

    public void OnClic() {
        TestGUIManager manager = FindObjectOfType<TestGUIManager>();
        manager.CreateStationView(_station.ID);
    }
}