using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] Transform lookAt;

    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = follow.position + offset;
        transform.LookAt(lookAt.position);
    }
}
