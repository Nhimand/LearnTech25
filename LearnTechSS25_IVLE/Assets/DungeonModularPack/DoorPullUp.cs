using UnityEngine;

public class DoorPullUp : MonoBehaviour
{
    public GameObject door;      
    public float moveAmount = 3f;
    public float speed = 2f;      

    private Vector3 targetPos;
    private bool shouldMove = false;

    void Start()
    {
        if (door != null)
        {
            targetPos = door.transform.position + Vector3.up * moveAmount;
        }
    }

    void Update()
    {
        if (shouldMove && door != null)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
