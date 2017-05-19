using UnityEngine;
using UnityEngine.UI;

public class HomeMenuControler : MonoBehaviour {

    [SerializeField]
    private InputField stationToLoad = null;

    public void OnPlayClic() {
        int zoneToLoad = 2;
        if (stationToLoad.text != "") {
            zoneToLoad = int.Parse(stationToLoad.text);
        }

        TransitionManager manager = GameObject.FindObjectOfType<TransitionManager>();
        manager.LoadNewStationZone(zoneToLoad);
    }
}