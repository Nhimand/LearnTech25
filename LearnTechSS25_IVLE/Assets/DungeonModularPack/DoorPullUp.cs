using UnityEngine;

public class DoorPullUp : MonoBehaviour
{
    public GameObject door;
    public float moveAmount = 3f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool shouldMove = false;

    void Start()
    {
        if (door != null)
        {
            startPos = door.transform.position;
            targetPos = startPos + Vector3.up * moveAmount;
        }
    }

    void Update()
    {
        if (shouldMove && door != null)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, speed * Time.deltaTime);
        }
    }


    //testing
    public void OnButtonClick()
    {
        shouldMove = true;
    }
}
