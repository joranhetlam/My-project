using UnityEngine;
using System.Collections;

public class SaturationTarget : MonoBehaviour
{
    public Transform FingerPoint;

    [SerializeField] private float measurementTime = 3f;

    [SerializeField] private int saturation = 98;

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

        pickup.MoveToTarget(FingerPoint);

        float timer = measurementTime;

        while (timer > 0)
        {
            InformationBoardController.Instance.ShowCountdown(
                Mathf.Ceil(timer));

            timer -= Time.deltaTime;

            yield return null;
        }

        InformationBoardController.Instance.SaturationFinished(saturation);
        toolDisplay.ShowValue(
            saturation.ToString("98") + " %");

        GameManager.Instance.SelectedTool.PlayMeasurementSound();

        pickup.Pickup(GameManager.Instance.HandPoint);
    }
}