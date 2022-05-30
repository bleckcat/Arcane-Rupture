using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    GameObject[] player;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("press E to interact");
        }
        // if (player[0].transform.hasChanged)
        // {
        //   float distance = Vector3.Distance(transform.position, player[0].transform.position);
        //   if (distance <= radius)
        //   {
        //     Debug.Log("can interact");
        //   }
        //   player[0].transform.hasChanged = false;
        // }
    }
}
