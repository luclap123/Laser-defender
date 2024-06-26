using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 valueInput;
    [SerializeField] float speed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
    private void Controller()
    {
        Vector2 delta = valueInput * speed * Time.deltaTime;
        // used to constrain a numerical value within a specific range
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        valueInput = value.Get<Vector2>();
        // Debug.Log(valueInput);
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
