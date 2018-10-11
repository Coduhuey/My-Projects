using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start() //called everytime the gameobject brought into the scene
    {
        Destroy(gameObject, m_MaxLifeTime); //it will be destroyed after two seconds
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        //similiar to raycast(start, end, layermask) which is just a line, Physics.OverlapSphere(position, radius, layermask) collects all objects in the sphere and puts it into the colliders array

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody) //if no rigidbody can be found
                continue;

            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            //(Rigidbody variable).AddExplosionForce(value of magnitude, position it eminates from, the radius), just adds an explosion like force

            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
            //gameobject with rigidbody instance of the TankHealth script for the target tank

            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }

        m_ExplosionParticles.transform.parent = null; //removes the gameobject as the parent

        m_ExplosionParticles.Play();

        m_ExplosionAudio.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);

        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.

        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius; //relative position (value between 0 and 1) away from the explosion we're concerned about

        float damage = relativeDistance * m_MaxDamage;

        damage = Mathf.Max(0f, damage); //to ensure it isn't zero;

        return damage;
    }
}