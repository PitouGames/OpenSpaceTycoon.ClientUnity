using UnityEngine;

public class DataModel : MonoBehaviour {
    public OSTData.Universe Universe { get; set; }
    public OSTData.Corporation PlayerCorp { get; set; }

    private float time = 0.0f;
    private float timePerUpdate = 1.0f;

    private void Start() {
        Universe = new OSTData.Universe(0);
        Universe.Build();

        PlayerCorp = Universe.CreateCorp(1);

        OSTData.Station city = Universe.GetStation(2);
        city.CreateHangar(PlayerCorp);
        OSTData.Station mine = Universe.GetStation(6);
        mine.CreateHangar(PlayerCorp);
        OSTData.Ship ship = city.CreateShip(PlayerCorp);
        OSTData.ShipDestination dest = ship.AddDestination(city);
        dest.AddLoad(OSTData.ResourceElement.ResourceType.Wastes, 50);
        OSTData.ShipDestination dest2 = ship.AddDestination(mine);
        dest2.AddUnload(OSTData.ResourceElement.ResourceType.Wastes, 50);
        ship.Start();
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