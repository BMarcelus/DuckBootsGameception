using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniVolcano : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoint;
    public GameObject flamingRockPrefab;
    public float maxCoolupSeconds = 2f;
    public int maxNumberOfFlameRocks = -1;
    private float _currentTime = 0f;
    private int _currentFlameRockCount = 0;
    public float _initialMaxCoolUpDelay = 0f;

    private void Start() {
        this._initialMaxCoolUpDelay = Random.Range(0f, 1f) * 5f;
        
        // Random.InitState((int)(Random.Range(0, System.DateTime.Now.Ticks)));
    }
    private void FireFlame() {
        if (!spawnPoint) return;
        if (!flamingRockPrefab) return;
        if ((this.maxNumberOfFlameRocks > 0) && (this._currentFlameRockCount >= this.maxNumberOfFlameRocks)) return;

        this.maxNumberOfFlameRocks++;

        float angleRads = Random.Range(-Mathf.PI * 0.5f, Mathf.PI * 0.5f);
        float force = Random.Range(100f, 400f);
        
        GameObject instance = Instantiate(flamingRockPrefab, this.transform.position, Quaternion.identity);
        Rigidbody2D instanceRB = instance.GetComponent<Rigidbody2D>();
        instanceRB.AddForce(RadianToVector2(angleRads).normalized * force);
    }
    public static Vector2 RadianToVector2(float radian)
     {
         return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
     }

    // Update is called once per frame
    void Update()
    {
        this._currentTime += Time.deltaTime;

        if (this._currentTime >= (this.maxCoolupSeconds + this._initialMaxCoolUpDelay)) {
            this.FireFlame();
            this._currentTime = 0f;
        }
    }
}