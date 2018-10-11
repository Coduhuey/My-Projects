using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;

    
    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;    //every thing that will be current is private 
    private bool m_Fired;                


    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerNumber;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime; //(distance over time makes speed)
    }
    

    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.

        m_AimSlider.value = m_MinLaunchForce;

        if(m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        { //max charge, not fired

            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }

        else if (Input.GetButtonDown(m_FireButton))
        {  //fire is pressed for the first time (no need to check if you haven't fired because it's obvious if you just started holding the button)

            m_Fired = false;

            m_CurrentLaunchForce = m_MinLaunchForce;

            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();

        }

        else if(Input.GetButton(m_FireButton) && !m_Fired)
        {  //button is still held but hasn't fired yet

            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;

        }
        
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {  //button is released and haven't fired yet

            Fire();

        }

    }


    private void Fire()
    {
        // Instantiate and launch the shell.

        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; //.forward is added to make sure the shell is shot forward

        m_ShootingAudio.clip = m_FireClip; //stops previous clip from playing
        m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}