using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Detector _detector;
    [SerializeField] private float _changeVolumeSpeed;

    private Coroutine _volumeChanging;
    private int _startValue;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void OnEnable()
    {
        _audio.Play();
        _audio.volume = _startValue;

        _detector.Entered += OnEntered;
        _detector.Exited += OnExited;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnEntered;
        _detector.Exited -= OnExited;
    }

    public void OnEntered()
    {
        if (_volumeChanging != null)
            StopCoroutine(_volumeChanging);

        _volumeChanging = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void OnExited()
    {
        if (_volumeChanging != null)
            StopCoroutine(_volumeChanging);

        _volumeChanging = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audio.volume != volume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, volume, _changeVolumeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}