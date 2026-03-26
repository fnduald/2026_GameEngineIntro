using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
