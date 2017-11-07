using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField]
    float moveSpeed, jumpSpeed;

    PlayerMotor motor;

    private Vector2 touchOrigin = -Vector2.one;

    [SerializeField]
    TMPro.TextMeshProUGUI test_text;

    // Use this for initialization
    void Start()
    {
        motor = gameObject.GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = 0.0f;
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;// * Time.deltaTime;
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        print("Touched: " + Input.touchCount);
        test_text.text = "Touched: " + Input.touchCount;
        if (Input.touchCount == 1) {
            Touch touchInput = Input.touches[0];
            if (touchInput.position.x < Screen.width / 2) {
                speedX = -1 * moveSpeed;
            } else {
                speedX = 1 * moveSpeed;
            }
        }
#endif

        motor.MoveBody(speedX);
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            motor.jump(jumpSpeed);
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        if (Input.touchCount == 1) {
            motor.jump(jumpSpeed);
        }
#endif
    }
}
