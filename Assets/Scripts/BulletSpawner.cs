using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //생성된 탄알의 원본 프리펩을 변수 만들기
    public GameObject bulletPerFeb;
    //최초 생성 주기
    public float spawnRate = 0.5f;
    //최대 생성 주기
    public float spawnRateMax = 3f;

    Transform target; // 발사할 대상
    float spawnRateStart; // 생성 주기 
    float timeAfterSpawn; //최근 생성 시점에서 지난 시간. 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //최근 생성 이후의 무적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        //탄알 생성 간격을 정하기 
        spawnRateStart = Random.Range(spawnRate, spawnRateMax);

        //playerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindFirstObjectByType<PlyaerController>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        //시간을 갱신 시켜야 되기 떄문에 
        timeAfterSpawn += Time.deltaTime;
        
        //최근 생성 시점에서부터 누적된 시간이 생성주기보다 크거나 같다면
        if(timeAfterSpawn >=spawnRateStart)
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //bulletPerfab의 복제본을 만들고
            //transform.postion 위치와 transform.roatation 회전으로 생성
            //변수명은 bullet.

            //instantilate(프리팹 원본 , p ,r)
            GameObject bullet = Instantiate(bulletPerFeb,transform.position,transform.rotation);

            //생성된 bullet 게임오브젝트의 정면방향이 target을 향하도록 회전 
            bullet.transform.LookAt(target);

            //다음 생성 간격을 spawn 최소시간 ~ 최대시간 사이의 랜덤 지정 
            spawnRateStart = Random.Range(spawnRate, spawnRateMax);



        }

    }
}
