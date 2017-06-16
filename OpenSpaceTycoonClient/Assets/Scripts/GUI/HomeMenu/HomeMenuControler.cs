using UnityEngine;

public class HomeMenuControler : MonoBehaviour {

    public void OnPlayClic() {
        int zoneToLoad = 2;

        TransitionManager manager = GameObject.FindObjectOfType<TransitionManager>();
        manager.LoadNewStationZone(zoneToLoad);
    }
}