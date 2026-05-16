using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄환의 이동속력
    Rigidbody rig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody>();

        //리지드바디의 속도 = 앞쪽방향 * 이동 속력
        rig.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 playerController컴포넌트 가져오기
            PlyaerController playerCon = other.GetComponent<PlyaerController>();

            if(playerCon != null ) 
            {
                // plyaercontroller에 있는 die()gkatn tlfgod
                playerCon.Die();
            }
        }
    }
}
