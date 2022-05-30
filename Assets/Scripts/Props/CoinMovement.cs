using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float radius = 6f;
    float coinSpeed = 6f;
    Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance =
          Vector3.Distance(transform.position, player.position);
        float coinToPlayer = (coinSpeed / distance) * Time.deltaTime;
        if (distance <= radius)
        {
            this.transform.position =
              Vector3
                .MoveTowards(transform.position,
                new Vector3(player.position.x,
                  transform.position.y,
                  player.position.z),
                coinToPlayer);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
