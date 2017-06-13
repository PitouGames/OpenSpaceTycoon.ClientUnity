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

    [SerializeField]
    private TMPro.TextMeshProUGUI buying = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI standing = null;

    [System.NonSerialized]
    private Station _station = null;

    public void SetStation(Station station) {
        _station = station;
        hangarView.SetZone(station.GetHangar(-1));

        UpdateView();
    }

    public void OnCreateShipClic() {
        DataModel model = FindObjectOfType<DataModel>();
        _station.CreateShip(model.PlayerCorp);
    }

    private void UpdateView() {
        if (null != _station) {
            stationName.text = _station.Name;
            stationType.text = _station.Type.ToString();
            string tmp = "buying : ";
            foreach (var b in _station.Buyings) {
                tmp += b.ToString() + " for " + _station.GetBuyingPrice(b) + " ICU";
            }
            buying.text = tmp;
            tmp = "standing : ";
            foreach (ResourceElement.ResourceType t in System.Enum.GetValues(typeof(ResourceElement.ResourceType))) {
                tmp += t.ToString() + ":" + _station.GetStanding(t, 1) + "\n";
            }
            standing.text = tmp;
        }
    }
}