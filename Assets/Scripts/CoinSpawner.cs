using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin;
    public Tilemap tilemap;
    public int maxCoins = 3;

    private List<GameObject> spawnedCoins = new List<GameObject>();

    void Start(){
        SpawnCoins();
    }

    void Update(){
        if (spawnedCoins.Count == 0){
            SpawnCoins();
        }

    }

    void SpawnCoins(){
        for(int i = 0; i < maxCoins; i++){
            Vector3 randomPosition = GetRandomPositionOnTilemap();
            GameObject newCoin = Instantiate(coin, randomPosition, Quaternion.identity);
            spawnedCoins.Add(newCoin);

            Coin coinComponent = newCoin.GetComponent<Coin>();
            if (coinComponent != null){
                coinComponent.OnCollected += () => spawnedCoins.Remove(newCoin);
            }
        }
    }

     Vector3 GetRandomPositionOnTilemap()
    {

        BoundsInt bounds = tilemap.cellBounds;

        int randomX = Random.Range(bounds.xMin, bounds.xMax);
        int randomY = Random.Range(bounds.yMin, bounds.yMax);

        Vector3Int cellPosition = new Vector3Int(randomX, randomY, 0);
        Vector3 worldPosition = tilemap.GetCellCenterWorld(cellPosition);
        while (!IsValidSpawnPosition(cellPosition))
        {
            randomX = Random.Range(bounds.xMin, bounds.xMax);
            randomY = Random.Range(bounds.yMin, bounds.yMax);
            cellPosition = new Vector3Int(randomX, randomY, 0);
            worldPosition = tilemap.GetCellCenterWorld(cellPosition);
        }

        return worldPosition;
    }


     bool IsValidSpawnPosition(Vector3Int cellPosition)
    {

        TileBase tile = tilemap.GetTile(cellPosition);
        return tile != null;
    }


}
