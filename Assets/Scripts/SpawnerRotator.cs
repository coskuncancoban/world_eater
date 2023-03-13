using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRotator : MonoBehaviour
{
    //private float distance = 10f; // objenin merkeze olan mesafesi
    public float speed = 10f; // dönüş hızı

    // Objemizi merkeze olan uzaklıkta, y ekseni etrafında belli bir hızda döndürüyoruz.
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime); // objeyi Z ekseninde döndürür
    }
}
