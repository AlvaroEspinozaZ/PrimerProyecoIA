using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviursIA : MonoBehaviour
{
    public Transform Point;
    [SerializeField] float velocity, velocity0, velocityf;

    [Header("Seek")]
    [SerializeField] bool SeekB; 
    [SerializeField] float time;

    [Header("Arrive")]
    [SerializeField] bool ArriveB;
    public float slowingDistance = 5f; // Distancia a partir de la cual el objeto comenzará a desacelerar
    public float stoppingDistance = 1f; // Distancia a partir de la cual el objeto se detendrá

    [Header("Flee")]
    [SerializeField] bool FleeB;
    [SerializeField] float distanciaPrudente;

    [Header("Evade")]
    [SerializeField] bool EvadeB;
    [SerializeField] float voltereta,casiChoque;

    [Header("Pursuit")]
    [SerializeField] bool PursuitB;

    private void Awake()
    {
       
    }
    private void Update()
    {
        Seek(SeekB);
        Arrive(ArriveB);
        Flee(FleeB);
        Evade(EvadeB);
        Pursuit(PursuitB);
    }

    void Seek(bool SeekB)
    {
        if (SeekB)
        {
            Vector3 direction = (Point.position - transform.position).normalized;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * velocity);
            transform.position += transform.forward * Time.deltaTime * velocity;
   
        }
    }
    void Arrive(bool ArriveB)
    {
        if (ArriveB)
        {   
            // Calcula la dirección hacia el objetivo
            Vector3 targetDirection = Point.position - transform.position;

            // Calcula la distancia al objetivo
            float distance = targetDirection.magnitude;

            // Calcula la velocidad deseada
            float desiredSpeed = velocity;

            // Si estamos dentro de la distancia de frenado, ajusta la velocidad
            if (distance < slowingDistance)
            {
                desiredSpeed = velocity * (distance / slowingDistance);
            }

            // Si estamos dentro de la distancia de parada, detén completamente
            if (distance < stoppingDistance)
            {
                desiredSpeed = 0f;
            }


            // Calcula la fuerza de dirección hacia la velocidad deseada
            transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

            transform.position += transform.forward * Time.deltaTime * desiredSpeed;
        }
        
    }
    void Flee(bool FleeB)
    {
        if (FleeB)
        {
            if((transform.position - Point.position).magnitude < distanciaPrudente)
            {
                // Calcula la dirección hacia el objetivo
                Vector3 targetDirection = transform.position - Point.position;


                // Calcula la distancia al objetivo
                float distance = targetDirection.magnitude;

                // Calcula la velocidad deseada
                float desiredSpeed = velocity;

                // Si estamos dentro de la distancia de frenado, ajusta la velocidad
                if (distance < slowingDistance)
                {
                    desiredSpeed = velocity * (distance / slowingDistance);
                }

                // Si estamos dentro de la distancia de parada, detén completamente
                if (distance < stoppingDistance)
                {
                    desiredSpeed = 0f;
                }


                // Calcula la fuerza de dirección hacia la velocidad deseada
                transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

                transform.position += transform.forward * Time.deltaTime * desiredSpeed;
            }
        
        }
    }

    void Evade(bool EvadeB)
    {
        if (EvadeB)
        {
            
                // Calcula la dirección hacia el objetivo
                Vector3 targetDirection =  Point.position- transform.position;

                float desiredSpeed = velocity;

                float distanceToTarget = Vector3.Distance(transform.position, Point.position);

                if (distanceToTarget < 2.3f) // Puedes ajustar este valor según lo cerca que quieras que esté el objeto antes de evadir
                {
                    Vector3 evadeDirection = -targetDirection; // Invierte la dirección
                    transform.rotation = Quaternion.LookRotation(evadeDirection.normalized);
                    transform.position += evadeDirection * desiredSpeed * Time.deltaTime;
                }           
        }
    }

    void Pursuit(bool PursuitB)
    {
        if (PursuitB)
        {
            Vector3 direction = (Point.position - transform.position).normalized;
            // Calcula la dirección hacia el objetivo
            Vector3 targetDirection = Point.position - transform.position;

            // Calcula la distancia al objetivo
            float distance = targetDirection.magnitude;

            // Calcula la velocidad deseada
            float desiredSpeed = velocity;

            // Si estamos dentro de la distancia de frenado, ajusta la velocidad
            if (distance < slowingDistance)
            {
                desiredSpeed = velocity * (distance / slowingDistance);
            }

            // Si estamos dentro de la distancia de parada, detén completamente
            if (distance < stoppingDistance)
            {
                desiredSpeed = 0f;
            }


            // Calcula la fuerza de dirección hacia la velocidad deseada
            transform.rotation = Quaternion.LookRotation(targetDirection.normalized);

            transform.position += targetDirection * Time.deltaTime * desiredSpeed;
        }

    }
}
