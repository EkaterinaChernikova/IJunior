using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private int alarmVolumeChange = -1;
    [SerializeField] private float volumeChangeSpeed = 0.5f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = transform.GetChild(1).GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() == true)
        {
            StartAlarm();
        }
    }

    private IEnumerator ChangeVolume(int volumeChange)
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
        
        do
        {
            _audioSource.volume += volumeChange * Time.deltaTime * volumeChangeSpeed;
            yield return null;
        }
        while (_audioSource.volume > 0 && _audioSource.volume < 100);
        
        if(_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }

    public void StartAlarm()
    {
        Debug.Log("ALARM");
        alarmVolumeChange *= -1;
        StartCoroutine(ChangeVolume(alarmVolumeChange));
    }
}
