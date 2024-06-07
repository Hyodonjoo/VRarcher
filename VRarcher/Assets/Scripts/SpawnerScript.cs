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
    public float spawnInterval = 10f; // ������ ��ȯ�Ǵ� ���� (10��)
    private float spawnTimer=0f; // ��ȯ Ÿ�̸�
    private int AnimalCount=0; // �� ��� ��ȯ
    private Vector3 randomPosition;
                             
    // ���� �������� ������ ť
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
            // ť�� ����Ʈ�� ��ȯ
            List<GameObject> animalList = new List<GameObject>(animalQueue);

            // ����Ʈ���� �����ϰ� ����
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
            Destroy(spawnedAnimal, 30f); //30�� �� ���� 
        }

  

        
    }

}

    

