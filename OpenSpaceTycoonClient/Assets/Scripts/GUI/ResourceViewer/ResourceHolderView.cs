using UnityEngine;
using UnityEngine.UI;

public class ResourceHolderView : MonoBehaviour {

    [SerializeField]
    private GridLayoutGroup iconZone = null;

    [SerializeField]
    private ResourceIcon iconPrefab = null;

    public void SetZone(OSTData.ResourceHolder zone) {
        foreach (OSTData.ResourceStack s in zone.ResourceStacks) {
            ResourceIcon obj = Instantiate<ResourceIcon>(iconPrefab);
            obj.transform.SetParent(iconZone.transform);
            obj.SetData(s);
        }
    }
}