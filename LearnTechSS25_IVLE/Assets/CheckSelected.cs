using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckSelected : MonoBehaviour
{
    public bool isDeactivated;

    void OnDeactivated(DeactivateEventArgs args)
    {
        isDeactivated = true;
    }


}
