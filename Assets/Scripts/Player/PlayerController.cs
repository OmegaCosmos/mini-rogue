using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WeaponHandler))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] public Vector2 speed = new Vector2(5, 5);
    float horizontalInput;
    float verticalInput;
    [SerializeField] GameObject bullet;
    Vector2 point;
    
    private WeaponHandler _weaponHandler;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        if(_rb == null) {
            Debug.LogError($"Failed to get component [{_rb.GetType()}]! This game object could be missing the relevant component");
        }

        _weaponHandler = gameObject.GetComponent<WeaponHandler>();
        if(_weaponHandler == null) {
            Debug.LogError($"Failed to get component [{_weaponHandler.GetType()}]! This game object could be missing the relevant component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Capture input values
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Left: -1  |  Right: 1
        verticalInput = Input.GetAxisRaw("Vertical"); // Down: -1  |  Up: 1

        if(Input.GetKeyDown(KeyCode.Space)) {
            _weaponHandler.Fire(gameObject.transform.position);
        }

        bullet.transform.position = Vector2.Lerp(transform.position, point, Time.deltaTime);
    }

    void FixedUpdate() {
        // Movement code here since physics calculations run better in FixedUpdate
        _rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
    }
}
