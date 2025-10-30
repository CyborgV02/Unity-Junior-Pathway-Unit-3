using System.Security;
using NUnit.Framework;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 10;
    public float gravityMod;
    private Rigidbody playerRb;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;




    public bool isOnGround = true;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMod;

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (playerRb.IsSleeping())
{
    playerRb.WakeUp();
}

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            Debug.Log("Game Over !");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtSplatter.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
