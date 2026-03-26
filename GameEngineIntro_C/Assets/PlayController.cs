using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myAnimator;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("move", false);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void Update()
    {
        // 캐릭터 좌우 반전 처리
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 애니메이션 파라미터 제어
        if (moveInput.magnitude > 0)
        {
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }

        // 실제 이동 처리
        transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);
   
    }
  
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Death")
        {
            // "Death"라는 이름의 오브젝트와 부딪히면 현재 씬을 다시 로드합니다.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // 그 외의 경우 "PlayScene_" 뒤에 부딪힌 오브젝트의 이름을 붙여 씬을 이동합니다.
            SceneManager.LoadScene("PlayScene_" + collision.name);
        }
    }

}