using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class MapEdges : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = 4;
        Vector3 cameraDirection = mainCamera.transform.forward;
        Vector3[] cameraCorners =
        {
            mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)),
            mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane)),
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane)),
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane))
        };
        for (int i = 0; i < cameraCorners.Length; i++)
        {
            lineRenderer.SetPosition(i, 
                cameraCorners[i] + cameraDirection * (cameraCorners[i].y / Vector3.Dot(cameraDirection, Vector3.down))
            );
        }
    }
}
