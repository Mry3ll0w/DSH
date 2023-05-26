using UnityEngine;

public class FieldOfViewVisualizer : MonoBehaviour
{
    public FieldOfView fov;

    private void OnDrawGizmos()
    {
        if (fov == null) return;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(fov.transform.position, fov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.radius);
        Gizmos.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.radius);

        if (fov.canSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
