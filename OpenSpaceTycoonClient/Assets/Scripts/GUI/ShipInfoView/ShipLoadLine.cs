using UnityEngine;

public class ShipLoadLine : MonoBehaviour {
    private OSTData.ShipDestination.LoadData _data;

    [SerializeField]
    private TMPro.TextMeshProUGUI typeName = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI qte = null;

    public void Setdata(OSTData.ShipDestination.LoadData data) {
        _data = data;
        typeName.text = _data.type.ToString();
        qte.text = _data.qte.ToString();
    }
}