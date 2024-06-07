using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Brown_bear_prefab;
    public GameObject Deer_male_prefab;
    public GameObject Wild_rabbit_prefab;
    public GameObject lb_sparrow;
    public GameObject Wild_boar_prefab;
    public int animalCount = 10;
    public float spawnInterval = 10f; // 동물이 소환되는 간격 (10초)
    private float spawnTimer=0f; // 소환 타이머
    private int AnimalCount=0; // 총 몇마리 소환
    private Vector3 randomPosition;
                             
    // 동물 프리팹을 저장할 큐
    private Queue<GameObject> animalQueue;

    void Start()
    {
        animalQueue = new Queue<GameObject>();

       // animalQueue.Enqueue(Brown_bear_prefab);
       // animalQueue.Enqueue(Deer_male_prefab);
        //animalQueue.Enqueue(Wild_rabbit_prefab);
      //  animalQueue.Enqueue(lb_sparrow);
        animalQueue.Enqueue(Wild_boar_prefab);

    }

    void Update()
    {

        spawnTimer += Time.deltaTime;

        if (AnimalCount <= 10 && spawnTimer >= spawnInterval)
        {
            SpawnAnimal();
            spawnTimer = 0f;
            AnimalCount++;
        }


    }

    void SpawnAnimal()
    {
        if(animalQueue.Count > 0)
        {
            // 큐를 리스트로 변환
            List<GameObject> animalList = new List<GameObject>(animalQueue);

            // 리스트에서 랜덤하게 선택
            int randomIndex = Random.Range(0, animalList.Count);
            GameObject selectedAnimal = animalList[randomIndex];
          
            if(selectedAnimal.name == "lb_sparrow")
            {
                randomPosition = new Vector3(Random.Range(75, 90), Random.Range(1, 7), Random.Range(70, 90));
            }
            else
            {
                randomPosition = new Vector3(Random.Range(75, 90), 1.0f, Random.Range(70, 90));
            }

            GameObject spawnedAnimal = Instantiate(selectedAnimal, randomPosition, Quaternion.identity);
            Destroy(spawnedAnimal, 30f); //30초 후 삭제 
        }

  

        
    }

}

    

