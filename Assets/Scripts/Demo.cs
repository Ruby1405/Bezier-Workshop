using UnityEngine;
using UnityEngine.Events;

public class Demo : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private LineRenderer curveRenderer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int segmentCount = 20;
    public Vector2 p0 = new Vector2(-5, 0);
    public Vector2 p1 = new Vector2(0, 5);
    public Vector2 p2 = new Vector2(5, 0);
    public Vector2 p3 = new Vector2(10, 5);
    [SerializeField][Range(0, 1)] private float t = 0.5f;

    [SerializeField] private UnityEvent ValueChanged;
    private bool isPlaying = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Play()
    {
        MoveCar(0);
        isPlaying = true;
    }
    void Stop()
    {
        isPlaying = false;
        MoveCar(0);
    }
    private void OnValidate()
    {
        PathChanged();
        MoveCar(t);
        ValueChanged.Invoke();
    }

    void PathChanged()
    {
        curveRenderer.positionCount = segmentCount + 1;
        for (int i = 0; i <= segmentCount; i++)
        {
            float t = (float)i / segmentCount;
            Vector2 point = GetPoint(t);
            curveRenderer.SetPosition(i, new Vector3(point.x, 0, point.y));
        }
        lineRenderer.positionCount = 4;
        lineRenderer.SetPosition(0, new Vector3(p0.x, 0, p0.y));
        lineRenderer.SetPosition(1, new Vector3(p1.x, 0, p1.y));
        lineRenderer.SetPosition(2, new Vector3(p2.x, 0, p2.y));
        lineRenderer.SetPosition(3, new Vector3(p3.x, 0, p3.y));


        MoveCar(t);
    }

    void MoveCar(float deltaT)
    {
        Vector2 carPosition = GetPoint(t);
        Vector2 tangent = GetTangent(t).normalized;

        car.position = new Vector3(carPosition.x, 0, carPosition.y);
        car.LookAt(car.position + new Vector3(tangent.x, 0, tangent.y));
    }

    Vector2 GetPoint(float t)
    {
        float u = 1 - t;
        return u * u * u * p0 + 3 * u * u * t * p1 + 3 * u * t * t * p2 + t * t * t * p3;
    }

    Vector2 GetTangent(float t)
    {
        float u = 1 - t;
        return 3 * u * u * (p1 - p0) + 6 * u * t * (p2 - p1) + 3 * t * t * (p3 - p2);
    }
}
