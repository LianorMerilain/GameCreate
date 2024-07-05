using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Audio : MonoBehaviour
{
    public AudioSource _audio;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _audio.Play();
        }
    }
}