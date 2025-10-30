using UnityEngine;

public class MoveLeft : MonoBehaviour
{


    private PlayerController playerControllerscript;
    private float leftBound = -15;
    

    public float speed = 30;
       void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (playerControllerscript.gameOver==false) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(transform.position.x<leftBound&& gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }


}
