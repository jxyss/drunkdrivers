using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BreakerBox : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private Renderer objectRenderer;

    private void Awake()
    {
        // Get components
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        objectRenderer = GetComponent<Renderer>();

        // Subscribe to select event
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        // Start the coroutine to wait 5 seconds and then display a debug message
        StartCoroutine(DelayedAction());
    }

    private System.Collections.IEnumerator DelayedAction()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5);

        // Display a debug message
        Debug.Log("Interaction worked after delay!");
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        interactable.selectEntered.RemoveListener(OnSelect);
    }
}