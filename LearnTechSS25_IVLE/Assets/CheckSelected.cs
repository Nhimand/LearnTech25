using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CheckSelected : MonoBehaviour
{
    public bool isDeactivated = false;
    private XRBaseInteractable interactable;

    void OnEnable()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        isDeactivated = false;
        Debug.Log("Deactivation");
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        isDeactivated = true;
        Debug.Log("Activation");
    }
}
