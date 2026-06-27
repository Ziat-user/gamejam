using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    [Header("コライダー情報")]
    public Collider playerCollider;
    public Collider toycarCollider;

    [Header("結果判定用")]
    public bool isToutch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //最初は触れていない
        isToutch = false;
    }

    // Update is called once per frame
    void Update()
    {
        isToutch = playerCollider.bounds.Intersects(toycarCollider.bounds);
        if(isToutch)
        {
            SceneManager.LoadScene("TitleScene");
 
        }
        
    }

    public bool IsToutch()
    {
        return isToutch;
    }
}
