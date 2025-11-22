using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Demo demoController;
    [SerializeField] private TextMeshProUGUI p0;
    [SerializeField] private TextMeshProUGUI p3;

    public void UpdateText()
    {
        p0.text = $"({demoController.p0.x}, {demoController.p0.y})";
        p3.text = $"({demoController.p3.x}, {demoController.p3.y})";
    }
    void OnValidate()
    {
        UpdateText();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
