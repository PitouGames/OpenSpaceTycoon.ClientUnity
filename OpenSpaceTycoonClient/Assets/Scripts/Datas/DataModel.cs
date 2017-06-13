using UnityEngine;

public class DataModel : MonoBehaviour {

    [System.NonSerialized]
    private OSTData.Universe _Universe = null;

    public OSTData.Universe Universe {
        get { return _Universe; }

        set { _Universe = value; }
    }

    public OSTData.Corporation PlayerCorp { get; set; }

    private float time = 0.0f;
    private float timePerUpdate = 1.0f;

    private void Start() {
        Application.runInBackground = true;

        Universe = new OSTData.Universe(0);
        Universe.Build();

        PlayerCorp = Universe.CreateCorp(1);
        PlayerCorp.AddICU(200, "starting");

        OSTData.Station city = Universe.GetStation(2);
        city.CreateHangar(PlayerCorp);
        OSTData.Station mine = Universe.GetStation(6);
        mine.CreateHangar(PlayerCorp);
        OSTData.Station reprocessing = Universe.GetStation(21);
        reprocessing.CreateHangar(PlayerCorp);
        OSTData.Ship ship = city.CreateShip(PlayerCorp);
        OSTData.ShipDestination dest = ship.AddDestination(city);
        dest.AddLoad(OSTData.ResourceElement.ResourceType.Wastes, 50);
        OSTData.ShipDestination dest2 = ship.AddDestination(mine);
        dest2.AddUnload(OSTData.ResourceElement.ResourceType.Wastes, 50);
        ship.Start();

        OSTData.Ship ship2 = mine.CreateShip(PlayerCorp);
        OSTData.ShipDestination dest3 = ship2.AddDestination(reprocessing);
        dest3.AddUnload(OSTData.ResourceElement.ResourceType.Wastes, 100);
        OSTData.ShipDestination dest4 = ship2.AddDestination(mine);
        dest4.AddLoad(OSTData.ResourceElement.ResourceType.Wastes, 100);
        ship2.Start();
    }

    private void Update() {
        time += Time.deltaTime;
        while (time > timePerUpdate) {
            time -= timePerUpdate;
            Universe.Update();
            OSTData.Ship s = Universe.Ships[0];
        }
    }
}