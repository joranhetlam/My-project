using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private bool isHeld = false;

    private Transform handPoint;

    private Transform moveTarget;

    private bool isMoving = false;

    public bool IsHeld => isHeld;

    private bool isReturning = false;

    [SerializeField]
    private Vector3 heldRotationOffset;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

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
        if (isReturning)
            return;

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
                isMoving = false;

            return;
        }

        if (!isHeld)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            handPoint.position,
            Time.deltaTime * 8f);

        Quaternion targetRotation =
            handPoint.rotation *
            Quaternion.Euler(heldRotationOffset);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * 8f);
    }

    public void ReturnToStart()
    {
        isHeld = false;
        isMoving = false;
        isReturning = true;

        StartCoroutine(ReturnRoutine());
    }

    private System.Collections.IEnumerator ReturnRoutine()
    {
        while (Vector3.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                startPosition,
                Time.deltaTime * 8f);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                startRotation,
                Time.deltaTime * 8f);

            yield return null;
        }

        transform.position = startPosition;
        transform.rotation = startRotation;

        isReturning = false;
    }
}