using UnityEngine;
using UnityEngine.UI;

public class MapView : MonoBehaviour {
    private OSTData.Universe _universe = null;

    [SerializeField]
    private GameObject stationPositionPrefab = null;

    [SerializeField]
    private RectTransform mapZone = null;

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;

        Debug.Log(universe.Systems.Count + " systems");

        foreach (int i in universe.Systems.Keys) {
            OSTData.StarSystem syst = universe.Systems[i];
            GameObject g = Instantiate(stationPositionPrefab) as GameObject;
            g.transform.SetParent(mapZone.transform);
            RectTransform r = g.GetComponent<RectTransform>();
            Debug.Log(syst.Name + " " + syst.Position.X + ":" + syst.Position.Z);
            r.anchoredPosition = new Vector2(syst.Position.X, syst.Position.Z);
        }
    }
}