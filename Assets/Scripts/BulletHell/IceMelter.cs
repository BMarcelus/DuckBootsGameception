using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelter : MonoBehaviour
{
    public float meltTime = 5f;
    public float minScale = 0.2f;
    public GameObject ice;
    public ParticleSystem waterDropsParticles;
    public GameObject burstEffect;
    public bool melting = true;
    private float timer = 0f;
    private Vector3 scalar = new Vector3(1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(melting) {
            timer += Time.deltaTime;
            float scale = (1-timer/meltTime)*(1-minScale)+minScale;
            scalar.Set(scale,scale,scale);
            ice.transform.localScale = scalar;
            if(timer>=meltTime) {
                OnMelt();
            }
        }
    }

    public void OnMelt() {
        MetaGameManager.instance.HoldItem(Item.ItemType.Key);
        Instantiate(burstEffect, transform.position, Quaternion.identity);
    }
    public void StartMelting() {
        melting = true;
        waterDropsParticles.gameObject.SetActive(true);
    }
    public void StopMelting() {
        melting = false;
        waterDropsParticles.gameObject.SetActive(false);
    }
}
