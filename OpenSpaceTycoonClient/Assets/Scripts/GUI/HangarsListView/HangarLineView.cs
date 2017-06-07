using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarLineView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI stationName = null;

    private OSTData.Hangar _hangar = null;

    public void SetHangar(OSTData.Hangar h) {
        _hangar = h;
        stationName.text = h.Station.Name;
    }
}