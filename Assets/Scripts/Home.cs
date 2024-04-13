using System.Collections;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Rogue>(out Rogue rogue))
            _alarm.SetStateAlarm(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Rogue>(out Rogue rogue))
            _alarm.SetStateAlarm(false);
    }
}
