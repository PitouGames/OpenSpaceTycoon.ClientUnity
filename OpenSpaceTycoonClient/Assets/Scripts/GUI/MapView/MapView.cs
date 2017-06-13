using UnityEngine;
using UnityEngine.UI.Extensions;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapView : MonoBehaviour {

    [System.NonSerialized]
    private OSTData.Universe _universe = null;

    [SerializeField]
    private RectTransform mapZone = null;

    [SerializeField]
    private StationOnMap stationOnMapPrefab = null;

    [SerializeField]
    private float zoomFactor = 0.05f;

    private Dictionary<OSTData.Station.StationType, Color> stationColor = new Dictionary<OSTData.Station.StationType, Color>();

    private void Awake() {
        stationColor.Add(OSTData.Station.StationType.Agricultural, Color.green);
        stationColor.Add(OSTData.Station.StationType.City, Color.red);
        stationColor.Add(OSTData.Station.StationType.FuelRefinery, Color.magenta);
        stationColor.Add(OSTData.Station.StationType.IceField, Color.blue);
        stationColor.Add(OSTData.Station.StationType.Mine, Color.black);
        stationColor.Add(OSTData.Station.StationType.Reprocessing, Color.cyan);
        stationColor.Add(OSTData.Station.StationType.RockRefinery, Color.grey);
        stationColor.Add(OSTData.Station.StationType.Shipyard, Color.yellow);
    }

    private void OnDestroy() {
        if (null != _universe) {
            _universe = null;
        }
    }

    public void SetUniverse(OSTData.Universe universe) {
        _universe = universe;

        Vector3[] posSystem1 = {new Vector3(400.0f, 0.0f, 0.0f),
                                new Vector3(-400.0f, 0.0f, 0.0f),
                                new Vector3(0.0f, 0.0f, -250.0f),
                                new Vector3(-200.0f, 0.0f, 125.0f),
                                new Vector3(200.0f, 0.0f, 125.0f) };

        foreach (OSTData.Station s in universe.GetStations()) {
            StationOnMap sOnMap = Instantiate<StationOnMap>(stationOnMapPrefab);
            sOnMap.transform.SetParent(mapZone.transform);
            RectTransform rt = sOnMap.GetComponent<RectTransform>();
            Vector3 pos = posSystem1[s.System.ID];
            pos += new Vector3((float)s.Position.X, (float)s.Position.Y, (float)s.Position.Z);
            rt.anchoredPosition = new Vector2(pos.x, pos.z);
            sOnMap.GetComponent<Image>().color = stationColor[s.Type];
            sOnMap.GetComponent<Image>().SetNativeSize();
        }

        GameObject StarPortals = new GameObject("portals");
        UILineRenderer splr = StarPortals.AddComponent<UILineRenderer>();
        StarPortals.transform.SetParent(mapZone.transform);
        RectTransform portalRT = StarPortals.GetComponent<RectTransform>();
        portalRT.SetAsFirstSibling();
        portalRT.anchoredPosition = Vector2.zero;
        portalRT.anchorMin = Vector2.zero;
        portalRT.anchorMax = Vector2.one;
        portalRT.pivot = Vector2.one;
        portalRT.sizeDelta = Vector2.zero;
        splr.Points = new Vector2[universe.Portals.Count * 2];
        splr.color = Color.red;
        splr.LineList = true;

        GameObject stationPortals = new GameObject("Portals internal");
        UILineRenderer stationlr = stationPortals.AddComponent<UILineRenderer>();
        stationPortals.transform.SetParent(mapZone.transform);
        RectTransform stationRT = stationPortals.GetComponent<RectTransform>();
        stationRT.SetAsFirstSibling();
        stationRT.anchoredPosition = Vector2.zero;
        stationRT.anchoredPosition = Vector2.zero;
        stationRT.anchorMin = Vector2.zero;
        stationRT.anchorMax = Vector2.one;
        stationRT.pivot = Vector2.one;
        stationRT.sizeDelta = Vector2.zero;
        stationlr.Points = new Vector2[universe.Portals.Count * 2];
        stationlr.color = Color.blue;
        stationlr.LineList = true;

        int index = 0;
        int index2 = 0;

        foreach (OSTData.Portal p in universe.Portals) {
            if (p.TypePortal == OSTData.Portal.PortalType.StarToStar) {
                Vector3 pos1 = posSystem1[p.Station1.System.ID] + new Vector3((float)p.Station1.Position.X, 0.0f, (float)p.Station1.Position.Z);
                splr.Points[index++] = new Vector2(pos1.x, pos1.z);
                Vector3 pos2 = posSystem1[p.Station2.System.ID] + new Vector3((float)p.Station2.Position.X, 0.0f, (float)p.Station2.Position.Z);
                splr.Points[index++] = new Vector2(pos2.x, pos2.z);
            } else {
                Vector3 pos1 = posSystem1[p.Station1.System.ID] + new Vector3((float)p.Station1.Position.X, 0.0f, (float)p.Station1.Position.Z);
                stationlr.Points[index2++] = new Vector2(pos1.x, pos1.z);
                Vector3 pos2 = posSystem1[p.Station2.System.ID] + new Vector3((float)p.Station2.Position.X, 0.0f, (float)p.Station2.Position.Z);
                stationlr.Points[index2++] = new Vector2(pos2.x, pos2.z);
            }
        }
    }

    public void OnScroll2() {
        float ratio = 1.0f;
        if (Input.mouseScrollDelta.y > 0.0f) {
            ratio += zoomFactor;
        } else {
            ratio -= zoomFactor;
        }
        mapZone.localScale = new Vector3(mapZone.localScale.x * ratio,
                                            mapZone.localScale.y * ratio,
                                            mapZone.localScale.z * ratio);
    }
}