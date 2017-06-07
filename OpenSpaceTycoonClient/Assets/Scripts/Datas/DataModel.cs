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
        bool test = false;
        foreach (OSTData.Station s in Universe.GetStations()) {
            if (test) {
                s.CreateHangar(PlayerCorp);
            }
            test = !test;
        }
    }

    private void Update() {
        time += Time.deltaTime;
        while (time > timePerUpdate) {
            time -= timePerUpdate;
            Universe.Update();
        }
    }
}