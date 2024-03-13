using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }


    [SerializeField] Tower towerPrefab;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            if (towerPrefab.CreateTower(towerPrefab, transform.position))
            {
                isPlaceable = false;
            }
        }
    }
}
