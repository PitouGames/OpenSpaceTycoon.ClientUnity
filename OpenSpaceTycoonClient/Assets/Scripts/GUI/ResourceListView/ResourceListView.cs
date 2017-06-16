using UnityEngine;

public class ResourceListView : MonoBehaviour {

    [SerializeField]
    private Transform content = null;

    [SerializeField]
    private resourceListLineView linePrefab = null;

    private void Start() {
        foreach (OSTData.ResourceElement.ResourceType t in System.Enum.GetValues(typeof(OSTData.ResourceElement.ResourceType))) {
            if (t == OSTData.ResourceElement.ResourceType.Unknown)
                continue;

            resourceListLineView line = Instantiate<resourceListLineView>(linePrefab);
            line.transform.SetParent(content);
            line.SetType(t);
        }
    }
}