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

    private void Start()
    {
        _audio.Play();
        _audio.volume = _startValue;
    }

    private void OnEnable()
    {
        _detector.Entered += OnEntered;
    }

    private void OnDisable()
    {
        _detector.Entered -= OnEntered;
    }

    public void OnEntered(float volume)
    {
        if (_volumeChanging != null)
            StopCoroutine(_volumeChanging);

        _volumeChanging = StartCoroutine(ChangeVolume(volume));
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