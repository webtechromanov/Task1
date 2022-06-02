using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            _transform.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));

        if (Input.GetKey(KeyCode.A))
            _transform.Translate(new Vector3(_speed * Time.deltaTime * -1, 0, 0));
    }
}
