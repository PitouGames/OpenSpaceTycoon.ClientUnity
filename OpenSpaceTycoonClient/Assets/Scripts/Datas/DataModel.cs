using UnityEngine;

public class DataModel : MonoBehaviour {
    public OSTData.Universe Universe { get; set; }

    private float time = 0.0f;

    private void Update() {
        time += Time.deltaTime;
        while (time > 0.2f) {
            time -= 0.2f;
            Universe.Update();
        }
    }
}