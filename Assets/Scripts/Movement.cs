using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private float _direction => _speed * Time.deltaTime;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(_direction, 0, 0));

        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-_direction, 0, 0));
    }
}
