using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private Transform handPoint;

    private void Start()
    {
        GameManager.Instance.SetHandPoint(handPoint);
    }
}