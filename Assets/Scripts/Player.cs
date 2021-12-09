using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("移動速度"), SerializeField]
    float moveSpeed = 4f;

    Rigidbody rb;

    /// <summary>
    /// 復活座標
    /// </summary>
    static Vector3 respawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (GameManager.CurrentState == GameManager.SceneChangeType.Retry)
        {
            // リトライ時は、保存してあったrespawnPositionへ復活
            transform.position = respawnPosition;
        }
        else
        {
            // ゲームスタートか、前のステージから来た場合は、respawnPositionに開始座標を代入
            respawnPosition = transform.position;
        }
    }

    void Update()
    {
        var v = rb.velocity;
        v.x = moveSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            respawnPosition = other.transform.parent.position;
            Destroy(other.gameObject);
        }
    }
}
