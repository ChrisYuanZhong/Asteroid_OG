using UnityEngine;

public class PillSpawner : MonoBehaviour
{
    public Pill pillPrefab;
    public float spawnRate = 30f;
    public float spawnDistance = 4f;

    // Start is called before the first frame update
    private void Start()
    {
        Spawn();
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    public void Spawn()
    {
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
        Vector3 spawnPoint = this.transform.position + spawnDirection;

        Pill pill = Instantiate(this.pillPrefab, spawnPoint, Quaternion.AngleAxis(0, Vector3.forward));
    }
}
