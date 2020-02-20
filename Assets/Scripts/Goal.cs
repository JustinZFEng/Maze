using UnityEngine;
using System.Collections;
public class Goal : MonoBehaviour
{
    static public bool goalMet = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Goal.goalMet = true;
        }
    }
}