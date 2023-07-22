using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private int alarmVolumeChange = -1;
    [SerializeField] private float volumeChangeSpeed = 0.5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Thief")
        {
            Debug.Log("ALARM");
            alarmVolumeChange *= -1;
        }
    }

    void Update()
    {
        GetComponent<AudioSource>().volume += alarmVolumeChange * Time.deltaTime * volumeChangeSpeed;
    }
}
