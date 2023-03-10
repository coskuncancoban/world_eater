using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBorder : MonoBehaviour
{
    private GameObject _player; // Player objesini referans almak için bir değişken

    private Vector3 _center = Vector3.zero; // FollowingBorder objesinin merkez noktası

    [SerializeField] private float _borderDistance = 20f; // FollowingBorder objesinin merkeze olan uzaklığı



    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //_player = GameObject.Find("Player"); // Player objesini bul
        transform.position = new Vector3(0f, _borderDistance, _player.transform.position.z); // FollowingBorder objesinin pozisyonunu Player objesinin pozisyonuna eşitle
        //transform.rotation *= Quaternion.Euler(0f, 0f, 90f);
    }

    private void Update()
    {

        transform.LookAt(_player.transform); // FollowingBorder objesini Player objesine bakacak şekilde döndür

        // FollowingBorder objesinin pozisyonunu güncelleme
        Vector3 playerPosition = _player.transform.position; // Player objesinin pozisyonunu al
        if (playerPosition.x != 0 && playerPosition.y != 0)// Player objesinin pozisyonu (0,0) değilse (Player objesinin pozisyonu (0,0) olduğunda FollowingBorder objesinin pozisyonu (0,0) oluyor. Bu yüzden FollowingBorder objesinin pozisyonu (0,0) olmasın diye bu koşulu ekledim.
        {
            transform.position = playerPosition.normalized * _borderDistance; // FollowingBorder objesinin pozisyonunu hesapla ve güncelle
            transform.rotation = Quaternion.LookRotation(Vector3.back, playerPosition.normalized); // FollowingBorder objesinin rotasyonunu ayarla
        }
    }
}
