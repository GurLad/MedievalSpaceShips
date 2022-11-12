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
    [SerializeField] float distanceToOutpost;
    [SerializeField] float secondsTillFoodLose;
    bool EelPowerActive = false;
    float timeSinceEelPowerUsed = 0;
    float distance;
    float foodCount;

    // Start is called before the first frame update
    void Start()
    {
        distance = PlayerResources.Current.Distance;
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
        PlayerResources.Current.Distance = distance - transform.position.x;
        PlayerResources.Current[ResourceType.Morale] += 0;
        if (PlayerResources.Current.Distance <= 0)
        {
            GameController.Current.Win();
            Destroy(this);
        }
        if (transform.position.x > distanceToOutpost)
        {
            GameController.Current.LoadNextPart();
            Destroy(this);
        }
        foodCount += Time.deltaTime;
        if (foodCount >= secondsTillFoodLose)
        {
            foodCount -= secondsTillFoodLose;
            PlayerResources.Current[ResourceType.Food]--;
            LoseCond();
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
            LoseCond();
        }
    }

    void LoseCond()
    {
        if (PlayerResources.Current[ResourceType.Health] <= 0 || PlayerResources.Current[ResourceType.Food] <= 0)
        {
            PlayerResources.Current.ResetData();
            GameController.Current.Lose();
            Destroy(this);
        }
    }
}
