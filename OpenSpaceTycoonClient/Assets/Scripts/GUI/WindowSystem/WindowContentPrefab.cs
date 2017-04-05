using UnityEngine;

/// <summary>
/// Class allowing to gives the details for the window system
/// </summary>
public class WindowContentPrefab : MonoBehaviour {

    /// <summary> The minimum widht this window can be </summary>
    [SerializeField]
    private int minWidthPixel = 100;

    /// <summary> The minimum height this window can be </summary>
    [SerializeField]
    private int minHeightPixel = 100;

    /// <summary> the category of this window type</summary>
    [SerializeField]
    private string windowName = "name";
}