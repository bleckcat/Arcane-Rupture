using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectCoin : MonoBehaviour
{
    [SerializeField]
    int coinQty = 0;

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Crystal":
                coinQty += 1558;
                break;
            case "Diamond":
                coinQty += 513;
                break;
            case "Emerald":
                coinQty += 257;
                break;
            case "Ruby":
                coinQty += 121;
                break;
            case "Amethyst":
                coinQty += 54;
                break;
        }
    }
}
