using UnityEngine;
using System.Collections;

public class TemperatureTarget : MonoBehaviour
{
    public Transform ForeheadPoint;

    public void Interact()
    {
        if (GameManager.Instance.SelectedTool == null)
        {
            Debug.Log("Geen thermometer geselecteerd.");
            return;
        }

        StartCoroutine(MeasureRoutine());
    }

    private IEnumerator MeasureRoutine()
    {
        PickupObject pickup =
            GameManager.Instance.SelectedTool.GetComponent<PickupObject>();

        pickup.MoveToTarget(ForeheadPoint);

        yield return new WaitForSeconds(3f);

        InformationBoardController.Instance.TemperatureFinished();

        pickup.Pickup(GameManager.Instance.HandPoint);
    }
}