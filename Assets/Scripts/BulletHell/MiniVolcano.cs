using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniVolcano : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoint;
    public GameObject flamingRockPrefab;
    public float minCoolupSeconds = 0f;
    public float maxCoolupSeconds = 2f;
    public float attackSpeed = 1f;
    public int maxNumberOfFlameRocks = -1;
    private float _currentTime = 0f;
    private int _currentFlameRockCount = 0;
    private float _initialMaxCoolUpDelay = 0f;
    public int arcCount = 3;
    public float arcAngle;
    private float myAngle;

    private void Start() {
        this._initialMaxCoolUpDelay = Random.Range(minCoolupSeconds, maxCoolupSeconds);
        myAngle = transform.eulerAngles.z;
        this._currentTime = this.attackSpeed;
    }
    private void OnEnable() {
        this._initialMaxCoolUpDelay = Random.Range(minCoolupSeconds, maxCoolupSeconds);
        this._currentTime = this.attackSpeed;
    }
    private void SpawnArc() {
        for(int i=0;i<arcCount;i++) {
            float angle = (i-arcCount/2) * arcAngle + myAngle;
            GameObject instance = Instantiate(flamingRockPrefab, this.transform.position, Quaternion.Euler(0,0,angle));
            instance.transform.parent = transform.parent;
        }
    }
    private void FireFlame() {
        if (!spawnPoint) return;
        if (!flamingRockPrefab) return;
        if ((this.maxNumberOfFlameRocks > 0) && (this._currentFlameRockCount >= this.maxNumberOfFlameRocks)) return;

        this.maxNumberOfFlameRocks++;

        float angleRads = Random.Range(Mathf.PI * 0.15f, Mathf.PI * 0.5f);
        float force = Random.Range(300f, 450f);
        
        GameObject instance = Instantiate(flamingRockPrefab, this.transform.position, Quaternion.identity);
        Rigidbody2D instanceRB = instance.GetComponent<Rigidbody2D>();
        instanceRB.AddForce(RadianToVector2(angleRads * (float)(Random.Range(-1, 1))).normalized * force);
    }
    public static Vector2 RadianToVector2(float radian)
     {
         return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
     }

    // Update is called once per frame
    void Update()
    {
        if(this._initialMaxCoolUpDelay>0) {
            this._initialMaxCoolUpDelay-=Time.deltaTime;
        } else {
            this._currentTime += Time.deltaTime;
            if (this._currentTime >= (this.attackSpeed)) {
                // this.FireFlame();
                this.SpawnArc();
                this._currentTime = 0f;
            }
        }
    }
}
