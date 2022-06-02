using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private Coroutine _changeVolume;

    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Awake()
    {
        _audio.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_changeVolume != null)
        {
            StopCoroutine(ChangeVolume(_minVolume));
            _changeVolume = null;
        }

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audio.Play();
            _changeVolume = StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_changeVolume != null)
        {
            StopCoroutine(ChangeVolume(_maxVolume));
            _changeVolume = null;
        }

        _changeVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audio.volume != volume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, volume, 0.1f * Time.deltaTime);
            yield return null;
        }
    }
}
