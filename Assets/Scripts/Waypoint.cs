using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            isPlaceable = false;
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
    }
}
