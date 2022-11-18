using UnityEngine;

/// <summary>
/// Class <c>PlayerController</c> handles spaceship movement, collision detection, win and loose condition
/// and collection or usage of resources, such as Eelpower, Food and Engines.
/// </summary>
///
public class PlayerController : MonoBehaviour
{
    Vector3 MoveInput;

    // Parameters
    [SerializeField] Rigidbody PlayerRigidBody;
    [SerializeField] float Speed;
    [SerializeField] float EelPowerSpeed;
    [SerializeField] int secondsOfEelPower;
    [SerializeField] float distanceToOutpost;
    [SerializeField] float secondsTillFoodLose;

    // State variables
    bool EelPowerActive = false;
    float timeSinceEelPowerUsed = 0;
    float distance;
    float foodCount;

    // Set the current distance left to the home planet at player controller initialization.
    void Start()
    {
        distance = PlayerResources.Current.Distance;
    }

    // On each update step, the movement input is set, the eel power trigger checked and
    // the time dependent resources (food, distance) set and acted accordingly.
    void Update()
    {
        // Handle movement input
        MoveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        MovePlayer();

        // Check if eel power is triggered
        if(Input.GetKeyDown("space"))
        {
            TriggerEelPower();
        }

        // If eel power is active set the time left until it is deactivated again
        if(EelPowerActive)
        {
            timeSinceEelPowerUsed += Time.deltaTime;
            if(timeSinceEelPowerUsed > secondsOfEelPower)
            {
                EelPowerActive = false;
                timeSinceEelPowerUsed = 0;
            }
        }

        // Set the distance to the home planet and check if the home planet or an outpost is reached
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

        // Handle the consumption of food 
        foodCount += Time.deltaTime;
        if (foodCount >= secondsTillFoodLose)
        {
            foodCount -= secondsTillFoodLose;
            PlayerResources.Current[ResourceType.Food]--;
            LoseCond();
        }
    }

    // Method to start the eel power
    void TriggerEelPower()
    {
        if(PlayerResources.Current[ResourceType.ElectricEels] > 0)
        {
            EelPowerActive = true;
            PlayerResources.Current[ResourceType.ElectricEels] -= 1;
        }
    }

    // Handle spaceship movement according to player input. The amount of speed depends on the number of engines collected
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

        // Only use y movement if player in bounds of camera 
        float yMovement = MoveVec.y;
        if((transform.position.y <= -4.0 && MoveInput.y <= 0) || (transform.position.y >= 6.0 && MoveInput.y >= 0))
        {
            yMovement = 0f;
        }
        else
        {
            yMovement = MoveVec.y;
        }

        // Set the velocity of the spaceship according to the player movement inputs
        PlayerRigidBody.velocity = new Vector3(MoveVec.x, yMovement, PlayerRigidBody.velocity.z);
    }

    // Method to handle collisions with other objects. Objects can be Resources or Obstacles.
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

    // Method to check if the health or food resource is empty, which leads to loosing the game
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
