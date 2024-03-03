using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
        }
    }
}
