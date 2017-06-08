using UnityEngine;
using UnityEngine.UI;

public class ResourceHolderView : MonoBehaviour {

    [SerializeField]
    private GridLayoutGroup iconZone = null;

    [SerializeField]
    private ResourceIcon iconPrefab = null;

    private OSTData.ResourceHolder _zone = null;

    private void OnDestroy() {
        _zone.onNewStack -= OnNewStack;
        _zone.onRemoveStack -= OnRemoveStack;
    }

    public void SetZone(OSTData.ResourceHolder zone) {
        _zone = zone;
        zone.onNewStack += OnNewStack;
        zone.onRemoveStack += OnRemoveStack;

        foreach (OSTData.ResourceStack s in zone.ResourceStacks) {
            ResourceIcon obj = Instantiate<ResourceIcon>(iconPrefab);
            obj.transform.SetParent(iconZone.transform);
            obj.SetData(s);
        }
    }

    private void OnNewStack(OSTData.ResourceStack stack) {
        ResourceIcon obj = Instantiate<ResourceIcon>(iconPrefab);
        obj.transform.SetParent(iconZone.transform);
        obj.SetData(stack);
    }

    private void OnRemoveStack(OSTData.ResourceStack stack) {
        foreach (var s in iconZone.transform.GetComponentsInChildren<ResourceIcon>()) {
            if (s.Stack.Equals(s)) {
                Destroy(s.gameObject);
            }
        }
    }
}