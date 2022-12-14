using UnityEngine;
using Zenject;
using static Zenject.CheatSheet;

public class PlayerController : MonoBehaviour
{
    // Fields --------------------------------------------
    public float moveSpeed = 5;

    float moveHorizontal;
    float moveVertical;
    
    // ---------------------------------------------------



    // Properties ----------------------------------------

    // ---------------------------------------------------



    // Events --------------------------------------------

    // ---------------------------------------------------



    // Injection -----------------------------------------
    [Inject]
    private void Constructor()
    {
        
    }
    // ---------------------------------------------------



    // Unity Methods -------------------------------------
    protected void Start()
    {
        
    }
    
    protected void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        

        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.deltaTime;
        Vector2 move = Vector2.zero;

        move.x += moveAmount * moveHorizontal;
        move.y += moveAmount * moveVertical;

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            move *= moveAmount / moveMagnitude;
        }
        pos += move;

        transform.position = pos;
    }
    // ---------------------------------------------------



    // Other Methods -------------------------------------
    
    // ---------------------------------------------------
}
