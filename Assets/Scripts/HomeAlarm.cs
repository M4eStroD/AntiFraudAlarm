using System.Collections;
using UnityEngine;

public class HomeAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;

    [SerializeField] private float _maxSpeedChangeVolume = 0.5f;
    [SerializeField] private float _maxStepChangeVolume = 0.1f;

    private float _maxVolume = 1;

    private Coroutine _coroutineIncrease;
    private Coroutine _coroutineDecrease;

    private IEnumerator IncreaseVolumeAlarm()
    {
        WaitForSeconds wait = new WaitForSeconds(_maxSpeedChangeVolume);

        while (_alarmAudioSource.volume != _maxVolume)
        {
            float volume = Mathf.MoveTowards(_alarmAudioSource.volume, _maxVolume, _maxStepChangeVolume);
            _alarmAudioSource.volume = volume;

            yield return wait;
        }
    }

    private IEnumerator DecreaseVolumeAlarm()
    {
        WaitForSeconds wait = new WaitForSeconds(_maxSpeedChangeVolume);

        while (_alarmAudioSource.volume != 0)
        {
            float volume = Mathf.MoveTowards(_alarmAudioSource.volume, 0, _maxStepChangeVolume);
            _alarmAudioSource.volume = volume;

            yield return wait;
        }

        _alarmAudioSource.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rogue>())
        {
            if (_coroutineDecrease != null)
                StopCoroutine(_coroutineDecrease);

            _alarmAudioSource.Play();
            _coroutineIncrease = StartCoroutine(IncreaseVolumeAlarm());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rogue>())
        {
            if (_coroutineIncrease != null)
                StopCoroutine(_coroutineIncrease);

            _coroutineDecrease = StartCoroutine(DecreaseVolumeAlarm());
        }
    }
}
