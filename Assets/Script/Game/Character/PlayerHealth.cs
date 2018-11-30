using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public AudioSource audioSource;
    public UIShake uiShake;
    public Text timeText;

    public GameObject gameOver;
    public Animator anim;                                              // Reference to the Animator component.
    // Reference to the AudioSource component.
    CharacterController playerMovement;                         // Reference to the player's movement.
                             
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    public float lerpSpeed;
    public float colorSpeed;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
 
        playerMovement = GetComponent<CharacterController>();
        // Set the initial health of the player.
        currentHealth = startingHealth;
        
        
    }
   
    void Update()
    {
        if (currentHealth >= 10)
        {
            if (currentHealth != healthSlider.value)
            {
                // Set the health bar's value to the current health.
                healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * lerpSpeed);
            }
        }
        else
        {
            
            healthSlider.value = currentHealth;
            

        }

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        
    }
 


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        
      

        // Play the hurt sound effect.
        // Get UI to shake
        uiShake.ShakeUI(20f, 1f);

        
 

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }
  

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        //Time.timeScale = 0f;

        uiShake.gameObject.SetActive(false);
        gameOver.SetActive(true);
        anim.SetBool("GameOver", true);
        
        

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        //  audioSource.clip = deathClip;
        // audioSource.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
       
        
    }
}