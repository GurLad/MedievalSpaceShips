using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 MoveInput;

    [SerializeField] Rigidbody PlayerRigidBody;
    [SerializeField] float Speed;
    [SerializeField] float EelPowerSpeed;
    [SerializeField] int secondsOfEelPower;
    bool EelPowerActive = false;
    float timeSinceEelPowerUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        MovePlayer();

        if(Input.GetKeyDown("space"))
        {
            TriggerEelPower();
        }
        if(EelPowerActive)
        {
            timeSinceEelPowerUsed += Time.deltaTime;
            if(timeSinceEelPowerUsed > secondsOfEelPower)
            {
                EelPowerActive = false;
                timeSinceEelPowerUsed = 0;
            }
        }
    }

    void TriggerEelPower()
    {
        if(PlayerResources.Current[ResourceType.ElectricEels] > 0)
        {
            EelPowerActive = true;
            PlayerResources.Current[ResourceType.ElectricEels] -= 1;
        }
    }

    void MovePlayer()
    {
        // Movement Speed depends on amount of engines 
        Vector3 MoveVec;
        if(EelPowerActive)
        {
            MoveVec = transform.TransformDirection(MoveInput) * ((PlayerResources.Current[ResourceType.Engines])/2 + Speed) * EelPowerSpeed;
        }
        else
        {
            MoveVec = transform.TransformDirection(MoveInput) * ((PlayerResources.Current[ResourceType.Engines])/2 + Speed);
        }

        float yMovement = MoveVec.y;
        // Only use y movement if player in bounds of camera 
        if((transform.position.y <= -4.0 && MoveInput.y <= 0) || (transform.position.y >= 6.0 && MoveInput.y >= 0))
        {
            yMovement = 0f;
        }
        else
        {
            yMovement = MoveVec.y;
        }
        PlayerRigidBody.velocity = new Vector3(MoveVec.x, yMovement, PlayerRigidBody.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Resource"))
        {
            switch (collision.gameObject.name)
            {
                case "Eel":
                    PlayerResources.Current[ResourceType.ElectricEels] += 1;
                    break;
                case "Health":
                    PlayerResources.Current[ResourceType.Health] += 1;
                    break;
                case "Food":
                    PlayerResources.Current[ResourceType.Food] += 1;
                    break;
                case "Engines":
                    PlayerResources.Current[ResourceType.Engines] += 1;
                    break;
                case "Morale":
                    PlayerResources.Current[ResourceType.Morale] += 1;
                    break;
                default:
                    Debug.Log("unknown resource");
                    break;
            }
            Destroy(collision.gameObject);
            // Debug.Log(PlayerResources.Current[ResourceType.ElectricEels]);
        }
        else if(collision.gameObject.tag.Equals("Obstacle"))
        {
            PlayerResources.Current[ResourceType.Health] -= 1;
            Destroy(collision.gameObject);
        }
    }
}
