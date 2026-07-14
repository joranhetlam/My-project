using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private bool isHeld = false;

    private Transform handPoint;

    private Transform moveTarget;

    private bool isMoving = false;

    public bool IsHeld => isHeld;

    public void Pickup(Transform target)
    {
        if (isHeld)
            return;

        handPoint = target;

        isHeld = true;
    }

    public void MoveToTarget(Transform target)
    {
        moveTarget = target;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                moveTarget.position,
                Time.deltaTime * 8f);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                moveTarget.rotation,
                Time.deltaTime * 8f);

            if (Vector3.Distance(transform.position, moveTarget.position) < 0.01f)
            {
                isMoving = false;
            }

            return;
        }

        if (!isHeld)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            handPoint.position,
            Time.deltaTime * 8f);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            handPoint.rotation,
            Time.deltaTime * 8f);
    }
}