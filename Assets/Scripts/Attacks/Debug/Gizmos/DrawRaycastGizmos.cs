using UnityEngine;

public class DrawRaycastGizmos : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;
            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
#endif
}
