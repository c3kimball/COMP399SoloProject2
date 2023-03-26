using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Fred" || other.name == "Dave" || other.name == "Match" || other.name == "Mitch")
        {
            Destroy(other.gameObject);
        }
    }
}
