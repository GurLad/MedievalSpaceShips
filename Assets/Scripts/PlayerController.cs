using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 MoveInput;

    [SerializeField] Rigidbody PlayerRigidBody;
    [SerializeField] float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        MovePlayer();
        Debug.Log(MoveInput.x);
    }

    void MovePlayer()
    {
        Vector3 MoveVec = transform.TransformDirection(MoveInput) * Speed;
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
        }
    }
}
