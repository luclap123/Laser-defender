using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 valueInput;
    [SerializeField] float speed  = 5f;
    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    private void Controller()
    {
        Vector3 delta = valueInput * speed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        valueInput = value.Get<Vector2>();
        Debug.Log(valueInput);
    }
}
