using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{

    public Transform destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var position = other.transform.position;
            position = new Vector3(destination.position.x, position.y, position.z);
            other.transform.position = position;
        }
    }
}
