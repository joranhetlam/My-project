using UnityEngine;
using System.Collections;

public class BloodPressureTarget : MonoBehaviour
{
    public Transform ArmPoint;

    [SerializeField] private float measurementTime = 3f;

    [SerializeField]
    private string bloodPressure = "120 / 80";

    [SerializeField] private MedicalToolDisplay toolDisplay;

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

        pickup.MoveToTarget(ArmPoint);

        float timer = measurementTime;

        while (timer > 0)
        {
            InformationBoardController.Instance.ShowCountdown(
                Mathf.Ceil(timer));

            timer -= Time.deltaTime;

            yield return null;
        }

        InformationBoardController.Instance.BloodPressureFinished(bloodPressure);
        toolDisplay.ShowValue(bloodPressure);

        GameManager.Instance.SelectedTool.PlayMeasurementSound();

        pickup.Pickup(GameManager.Instance.HandPoint);
    }
}