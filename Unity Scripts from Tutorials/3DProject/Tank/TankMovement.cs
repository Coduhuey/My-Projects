using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;   //other tanks will use different keys      
    public float m_Speed = 12f;            
    public float m_TurnSpeed = 180f;       //multiplied
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f; //how much the original pitch could change

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         //to !find! the axes
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    //to use the values to apply to the axes
    private float m_TurnInputValue;        
    private float m_OriginalPitch;   //original should be varied      


    private void Awake() //when scene starts regardless of the tank
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerNumber; //choosing from the axis based on the player from the input manager in the edit, project settings bar.
        m_TurnAxisName = "Horizontal" + m_PlayerNumber; //if it's player 1 it will be Horizontal1 for example, it's finding it based on string

        m_OriginalPitch = m_MovementAudio.pitch;
    }
    

    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName); 
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);       //these axes have certain keys that change their values, the input is gathered from the variable axes to the input value

        EngineAudio();
    }


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

 /* This looks cool */ if(Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {                       //an audiosource needs a clip to play, this makes sure the right one is played
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange); //to randomly choose audio between the pitch from it's ranges

                m_MovementAudio.Play(); //whenever the audioclip is changed, the source needs to be played again
            }
        }
        else
        {
            if(m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);

                m_MovementAudio.Play();
            }
        }
    }


    private void FixedUpdate() //works for physics steps rather than every rendered scene step
    {
        // Move and turn the tank.
        Move();
        Turn();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.

        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime; //time.delta time smooths movement per second

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.

        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f); //Quaternion.Euler transforms three float variables into a quaternion variable

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation); //have to multiply quaternions, quaternion equivalent of Rigidbody.MovePosition(newPosition)
    }
}