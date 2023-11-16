using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    public bool OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            return true;
        }
        return false;
    }
}
