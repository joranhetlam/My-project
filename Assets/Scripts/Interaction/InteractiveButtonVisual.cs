using UnityEngine;

public class InteractiveButtonVisual : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material disabledMaterial;

    private MeshRenderer meshRenderer;

    private Vector3 originalPosition;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalPosition = transform.localPosition;

        SetDefault();
    }

    public void SetDefault()
    {
        meshRenderer.material = defaultMaterial;
        transform.localPosition = originalPosition;
    }

    public void SetDisabled()
    {
        meshRenderer.material = disabledMaterial;
        transform.localPosition = originalPosition;
    }

    public void SetSelected()
    {
        meshRenderer.material = selectedMaterial;

        transform.localPosition =
            originalPosition + new Vector3(0f, 0f, -0.01f);
    }
}