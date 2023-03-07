using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] float speed = 1f;
    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
