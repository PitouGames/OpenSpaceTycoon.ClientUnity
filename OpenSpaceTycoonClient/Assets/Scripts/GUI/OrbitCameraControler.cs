using UnityEngine;

public class OrbitCameraControler : MonoBehaviour {
    private Camera _cam = null;

    private void Start() {
        _cam = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            //                _cam.transform.Rotate(Vector3.up, Time.deltaTime, Space.World);
        }
    }
}