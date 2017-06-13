using UnityEngine;

public class ResourceInfosView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI resName = null;

    [SerializeField]
    private Transform producerContent = null;

    [SerializeField]
    private ResourceProducerLine producerLinePrefab = null;

    [SerializeField]
    private Transform consumerContent = null;

    public void SetData(OSTData.ResourceElement.ResourceType type) {
        DataModel model = FindObjectOfType<DataModel>();

        resName.text = type.ToString();
        foreach (var s in model.Universe.GetStations()) {
            if (s.IsProducing(type)) {
                ResourceProducerLine line = Instantiate<ResourceProducerLine>(producerLinePrefab);
                line.transform.SetParent(producerContent);
                line.SetStation(s);
            }
            if (s.Buyings.Contains(type)) {
                ResourceProducerLine line = Instantiate<ResourceProducerLine>(producerLinePrefab);
                line.transform.SetParent(consumerContent);
                line.SetStation(s);
            }
        }
    }
}