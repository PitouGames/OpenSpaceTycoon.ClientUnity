using UnityEngine;

public class MapView : MonoBehaviour {
    private OSTData.Universe _universe = null;

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;
    }
}