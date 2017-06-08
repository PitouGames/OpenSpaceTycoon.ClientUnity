using UnityEngine;

public class HangarView : MonoBehaviour {
    private OSTData.Hangar _hangar = null;
    private ResourceHolderView _resourceHold = null;

    private void Awake() {
        _resourceHold = GetComponentInChildren<ResourceHolderView>();
    }

    public void SetHangar(OSTData.Hangar h) {
        _hangar = h;
        _resourceHold.SetZone(h);
    }
}