using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] private GameObject Player;
    private bool isMovingLeft;
    private bool isMovingRight;

    private void Update()
    {
        if (isMovingLeft)
        {
            MoveLeft();
        }

        if (isMovingRight)
        {
            MoveRight();
        }
    }

    public void MovingLeft()
    {
        isMovingLeft = !isMovingLeft;
    }

    public void MovingRight()
    {
        isMovingRight = !isMovingRight;
    }

    public void MoveLeft()
    {
        Player.transform.position -= new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
    }

    public void MoveRight()
    {
        Player.transform.position += new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime;
    }
}
