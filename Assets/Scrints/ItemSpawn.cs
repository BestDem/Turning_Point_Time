using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class ItemSpawn : MonoBehaviour
{
    List<GameObject> objectL = new List<GameObject>();
    List<Material> materialL = new List<Material>();
    [SerializeField] private GameObject ring;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject stairs;
    [SerializeField] private Material black;
    [SerializeField] private Material red;
    [SerializeField] private Material blue;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spacingX = 11f;
    [SerializeField] private float spacingY = 14f;
    [SerializeField] private int objectsPerRow = 4;
    [SerializeField] private int totalUniqueObjects = 9;
    [SerializeField] private int clonesPerObject = 2;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<Vector3> spawnPositions = new List<Vector3>();

    private void Start()
    {
        objectL.Add(ring);
        objectL.Add(sphere);
        objectL.Add(stairs);

        materialL.Add(black);
        materialL.Add(red);
        materialL.Add(blue);

        GenerateSpawnPositions();
    }

    private void GenerateSpawnPositions()
    {
        spawnPositions.Clear();
        int totalObjects = totalUniqueObjects * (clonesPerObject + 1);
        int rows = Mathf.CeilToInt((float)totalObjects / objectsPerRow);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < objectsPerRow; col++)
            {
                if (spawnPositions.Count < totalObjects)
                {
                    Vector3 position = spawnPoint.position + new Vector3(col * spacingX, -row * spacingY, 0);
                    spawnPositions.Add(position);
                }
            }
        }
    }

    public void SpawnObjects()
    {
        // Очищаем предыдущие объекты
        foreach (var obj in spawnedObjects)
        {
            if (obj != null)
                Destroy(obj);
        }
        spawnedObjects.Clear();

        // Создаем список всех позиций
        List<Vector3> availablePositions = new List<Vector3>(spawnPositions);
        
        // Создаем уникальные объекты и их клоны
        for (int i = 0; i < totalUniqueObjects; i++)
        {
            GameObject prefab = objectL[Random.Range(0, objectL.Count)];
            Material material = materialL[Random.Range(0, materialL.Count)];

            // Создаем основной объект
            int posIndex = Random.Range(0, availablePositions.Count);
            GameObject mainObject = Instantiate(prefab, availablePositions[posIndex], Quaternion.identity);
            mainObject.GetComponent<Renderer>().material = material;
            spawnedObjects.Add(mainObject);
            availablePositions.RemoveAt(posIndex);

            // Создаем клоны
            for (int clone = 0; clone < clonesPerObject; clone++)
            {
                if (availablePositions.Count > 0)
                {
                    posIndex = Random.Range(0, availablePositions.Count);
                    GameObject cloneObject = Instantiate(prefab, availablePositions[posIndex], Quaternion.identity);
                    cloneObject.GetComponent<Renderer>().material = material;
                    spawnedObjects.Add(cloneObject);
                    availablePositions.RemoveAt(posIndex);
                }
            }
        }
    }
}
