using UnityEngine;

public class HangarListView : MonoBehaviour {
    private OSTData.Universe _universe = null;

    [SerializeField]
    private Transform content = null;

    [SerializeField]
    private HangarLineView linePrefab = null;

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;
        UpdateView();
    }

    private void UpdateView() {
        ClearHangars();

        if (null == _universe)
            return;
        foreach (OSTData.Station s in _universe.GetStations()) {
            OSTData.Hangar h = s.GetHangar(1);//todo magic number
            if (null != h) {
                AddHangar(h);
            }
        }
    }

    private void ClearHangars() {
        while (content.childCount > 0) {
            DestroyImmediate(content.GetChild(0));
        }
    }

    private void AddHangar(OSTData.Hangar h) {
        HangarLineView line = Instantiate<HangarLineView>(linePrefab);
        line.transform.SetParent(content);
        line.SetHangar(h);
    }
}