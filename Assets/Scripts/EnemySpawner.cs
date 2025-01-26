using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour {
    public enum LoopMode {
        ITERATE_THEN_END,
        ITERATE_THEN_GO_TO_FIRST,
        ITERATE_THEN_LOOP_LAST_ITEM
    }

    public GameObject enemyPrefab;
    public Transform target;
    public Vector3 variance = new(50.0f, 50.0f, 50.0f);
    public int maxEnemies = 3;
    public float deltaSpawn = 1.5f;

    public LoopMode loopMode = LoopMode.ITERATE_THEN_END;
    public List<float> waveSpawnTimes;

    public bool mIsLooping = true;
    public int mLoopIndex = 0;
    public int mSpawned = 0;
    public float mTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (waveSpawnTimes.Count == 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {
        mTimer += Time.deltaTime;
        // if (mTimer < delaySpawn) {
        //     return;
        // } else if (delaySpawn != -1 && mTimer >= delaySpawn) {
        //     // if we reached the delaySpawn time, set it to negative so that we don't check it again
        //     delaySpawn = -1;
        //     mTimer = 0;
        // }

        if ( mIsLooping ) {
            if ( mTimer >= waveSpawnTimes[ mLoopIndex ] ) {
                mTimer = 0;
                mSpawned = 0;
                mIsLooping = false;
            } else return;
        }

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
            switch (loopMode) {
                case LoopMode.ITERATE_THEN_END:
                    mLoopIndex++;
                    if (mLoopIndex >= waveSpawnTimes.Count)
                        Destroy(gameObject);
                    break;
                case LoopMode.ITERATE_THEN_GO_TO_FIRST: {
                    mLoopIndex++;
                    if (mLoopIndex >= waveSpawnTimes.Count)
                        mLoopIndex = 0;
                    break;
                }
                case LoopMode.ITERATE_THEN_LOOP_LAST_ITEM: {
                    mLoopIndex++;
                    if (mLoopIndex >= waveSpawnTimes.Count)
                        mLoopIndex = waveSpawnTimes.Count - 1;
                    break;
                }
            }

            mIsLooping = true;
        }

    }
}