using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public Transform target;
    public Vector3 variance = new(50.0f, 50.0f, 50.0f);
    public int maxEnemies = 3;
    public float deltaSpawn = 1.5f;

    public int mSpawned = 0;
    public float mTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        mTimer += Time.deltaTime;
        if ( mTimer >= deltaSpawn && mSpawned < maxEnemies ) {
            mTimer = 0;
            mSpawned++;
            var pos = transform.position + new Vector3(Random.Range(-variance.x, variance.x), Random.Range(-variance.y, variance.y), Random.Range(-variance.z, variance.z));
            var enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            enemy.transform.LookAt(target);
            var enemyrb = enemy.GetComponent<Rigidbody>();
            enemyrb.linearVelocity = enemyrb.transform.forward * 10.0f;
        }

        if (mSpawned >= maxEnemies) {
            Destroy(gameObject);
        }
    }
}