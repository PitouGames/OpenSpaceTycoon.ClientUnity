using System.Collections.Generic;
using UnityEngine;

public class PlaySceneLoader : MonoBehaviour {

    [SerializeField]
    private Transform world = null;

    [SerializeField]
    private GameObject agriculturalPrefab = null;

    [SerializeField]
    private GameObject cityPrefab = null;

    [SerializeField]
    private GameObject fuelRefineryPrefab = null;

    [SerializeField]
    private GameObject iceFieldPrefab = null;

    [SerializeField]
    private GameObject minePrefab = null;

    [SerializeField]
    private GameObject reprocessingPrefab = null;

    [SerializeField]
    private GameObject rockRefineryPrefab = null;

    [SerializeField]
    private GameObject shipyardPrefab = null;

    [SerializeField]
    private GameObject internalGatePrefab = null;

    [SerializeField]
    private GameObject externalGatePrefab = null;

    private void Start() {
        PlaySceneLoadData data = GameObject.FindObjectOfType<PlaySceneLoadData>();
        DataModel model = GameObject.FindObjectOfType<DataModel>();

        OSTData.Station station = model.Universe.GetStation(data.stationID);
        GameObject prefab = null;
        switch (station.Type) {
            case OSTData.Station.StationType.Agricultural:
            prefab = agriculturalPrefab;
            break;

            case OSTData.Station.StationType.City:
            prefab = cityPrefab;
            break;

            case OSTData.Station.StationType.FuelRefinery:
            prefab = fuelRefineryPrefab;
            break;

            case OSTData.Station.StationType.IceField:
            prefab = iceFieldPrefab;
            break;

            case OSTData.Station.StationType.Mine:
            prefab = minePrefab;
            break;

            case OSTData.Station.StationType.Reprocessing:
            prefab = reprocessingPrefab;
            break;

            case OSTData.Station.StationType.RockRefinery:
            prefab = rockRefineryPrefab;
            break;

            case OSTData.Station.StationType.Shipyard:
            prefab = shipyardPrefab;
            break;
        }

        GameObject newItem = Instantiate(prefab) as GameObject;
        newItem.transform.SetParent(world);
        newItem.transform.position = Vector3.zero;

        foreach (OSTData.Portal p in station.Gates) {
            switch (p.TypePortal) {
                case OSTData.Portal.PortalType.StarToStar:
                prefab = internalGatePrefab;
                break;

                case OSTData.Portal.PortalType.StationToStation:
                prefab = externalGatePrefab;
                break;
            }
            GameObject newGate = Instantiate(prefab) as GameObject;
            newGate.transform.SetParent(world);
            OSTTools.Vector3 pos = p.Position(station);
            pos *= 0.1;
            newGate.transform.position = new Vector3((float)pos.X, (float)pos.Y, (float)pos.Z);
            newGate.transform.LookAt(Vector3.zero);
        }

        GameObject.Destroy(data.gameObject);
    }
}