using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 50f;
    public Transform playerTransform;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = targetPos - playerTransform.position;
        Vector3 targetPosOnCircle = playerTransform.position + direction.normalized * radius;
        transform.position = targetPosOnCircle;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.RotateAround(playerTransform.position, Vector3.forward, speed * Time.deltaTime);
    }
}