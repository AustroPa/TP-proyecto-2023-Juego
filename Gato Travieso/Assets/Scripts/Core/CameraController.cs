
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed;
    
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    public float currentPosY;

    private void Update() {
        // ROOM CAMERA
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        currentPosY = player.position.y;
        //seguir jugador
        transform.position = new Vector3(player.position.x, player.position.y + 1.2f, transform.position.z);
    }

    /*
    public void MoveToNewRoom(Transform _newRoom) {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        currentPosX = _newRoom.position.x;   
    }

    public void ResetCam() {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
    */
}
