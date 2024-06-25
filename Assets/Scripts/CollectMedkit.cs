using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMedkit : MonoBehaviour
{
    public void MedkitCollect()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().MedkitUpdate(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().MedkitUpdate(null);
        }
    }
}
