using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;

    [SerializeField] private float _maxSpeedChangeVolume = 0.5f;
    [SerializeField] private float _maxStepChangeVolume = 0.1f;

    private float _maxVolume = 1;

    private bool _isAlarm = false;

    private void Start()
    {
        StartCoroutine(AlarmPlay());
    }

    public void SetStateAlarm(bool isAlarm)
    {
        _isAlarm = isAlarm;
    }

    private IEnumerator AlarmPlay()
    {
        WaitForSeconds wait = new WaitForSeconds(_maxSpeedChangeVolume);

        _alarmAudioSource.Play();
        float volume;

        while (true)
        {
            if (_isAlarm)
                volume = Mathf.MoveTowards(_alarmAudioSource.volume, _maxVolume, _maxStepChangeVolume);
            else
                volume = Mathf.MoveTowards(_alarmAudioSource.volume, 0, _maxStepChangeVolume);

            _alarmAudioSource.volume = volume;

            yield return wait;
        }
    }
}
