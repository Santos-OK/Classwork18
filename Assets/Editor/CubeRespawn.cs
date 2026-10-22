using UnityEngine;

public class CubeRespawn : MonoBehaviour
{
    Vector3 startPos; Quaternion startRot; Rigidbody rb;

    void Start() { startPos = transform.position; startRot = transform.rotation; rb = GetComponent<Rigidbody>(); }

    void Update()
    {
        if (transform.position.y < -2f)
        {
            rb.linearVelocity = Vector3.zero; rb.angularVelocity = Vector3.zero;
            transform.SetPositionAndRotation(startPos, startRot);
        }
    }
}