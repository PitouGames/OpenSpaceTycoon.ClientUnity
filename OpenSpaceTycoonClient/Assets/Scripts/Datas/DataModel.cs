using UnityEngine;

public class DataModel : MonoBehaviour {
    public OSTData.Universe Universe { get; set; }
    public OSTData.Corporation PlayerCorp { get; set; }

    private float time = 0.0f;

    private void Start() {
        Universe = new OSTData.Universe(0);
        foreach (var s in Universe.GetStations()) {
            s.InitProduct();
        }
        PlayerCorp = Universe.CreateCorp(1);
    }

    private void Update() {
        time += Time.deltaTime;
        while (time > 0.2f) {
            time -= 0.2f;
            Universe.Update();
        }
    }
}