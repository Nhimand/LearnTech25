using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CheckSelected : MonoBehaviour
{
    public bool isDeactivated = true;
    private XRBaseInteractable interactable;
    private bool toBeDublicated = false;
    private Vector3 startPos;
    private Quaternion startRot;
    private float randHoverDistance;
    private float HoverDuration = 2.0f;
    Vector3 hoverEndPoint;
    private Rigidbody rb;
    private Transform thisParent;
    private Coroutine hoverRoutine;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
        isDeactivated = true;
        startPos = transform.position;
        startRot = transform.rotation;
        randHoverDistance = Random.Range(0.1f, 0.2f);
        hoverEndPoint = startPos + new Vector3(0, randHoverDistance, 0);
        toBeDublicated = true;
        thisParent = transform.parent;
        

        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
        rb.isKinematic = true;
        hoverRoutine = StartCoroutine(MoveUp(hoverEndPoint,HoverDuration));
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
        rb.isKinematic = false;
        Debug.Log("Activation");
    }

    private void Update()
    {
        
        Vector2 curPos;
        curPos = new Vector2(transform.position.x, transform.position.z);
        if (toBeDublicated && Vector2.Distance(curPos, new Vector2(startPos.x, startPos.z)) > 0.1f)
        {
            toBeDublicated = false;
            StartCoroutine(MyDuplicate(10.0f));
        }
        if (!isDeactivated) 
        {
            StopCoroutine(hoverRoutine);
        }
    }

    IEnumerator MyDuplicate(float timer)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(gameObject, startPos, startRot, thisParent);
    }

    /// <summary>
    /// MoveUp() and MoveDown() make the object hover up and down continually until it is moved in x or z direction.
    /// </summary>
    /// <param name="hoverGoal">Endpoint for the hovering up/ startpoint for the hover back to original position.</param>
    /// <param name="duration">The time the up/down movement shall take.</param>
    /// <returns>The IEnumerator for the coroutine that is called in enable, also is called when one motion ends so object will continually hover up and down.</returns>
    IEnumerator MoveUp(Vector3 hoverGoal, float duration)
    {
        //if (Vector2.Distance(new Vector2(startPos.x, startPos.z), new Vector2(transform.position.x, transform.position.z)) > 0.01f)
        
        float elapsed = 0f;
        while (elapsed < duration) 
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPos, hoverGoal, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = hoverEndPoint;
        hoverRoutine = StartCoroutine(MoveDown(hoverGoal, duration));
    }

    IEnumerator MoveDown(Vector3 hoverGoal, float duration)
    {
        //if (Vector2.Distance(new Vector2(startPos.x, startPos.z), new Vector2(transform.position.x, transform.position.z)) > 0.01f)
        
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(hoverGoal, startPos, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;
        randHoverDistance = Random.Range(0.2f, 0.5f);
        hoverEndPoint = startPos + new Vector3(0, randHoverDistance, 0);
        hoverRoutine = StartCoroutine(MoveUp(hoverEndPoint, duration));
    }

}
