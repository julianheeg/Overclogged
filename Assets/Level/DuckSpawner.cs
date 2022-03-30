using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    private float next_spawn;
    public GameObject duck_prefab;
    new bool enabled;
    public AudioClip[] quacks;


    // Start is called before the first frame update
    void Start()
    {
        next_spawn = Random.Range(config.DUCK_SPAWN_MIN_INTERVAL, config.DUCK_SPAWN_MAX_INTERVAL);
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            next_spawn -= Time.deltaTime;
            if (next_spawn <= 0)
            {
                float y_value = Random.Range(config.DUCK_DOWNMOST_POSITION, config.DUCK_UPMOST_POSITION);
                float sorting = (y_value - config.DUCK_DOWNMOST_POSITION) / (config.DUCK_UPMOST_POSITION - config.DUCK_DOWNMOST_POSITION);
                //Debug.Log((new Vector3(13, y_value, sorting)).ToString());

                GameObject new_duck = Instantiate(duck_prefab, new Vector3(9.5f, y_value, sorting), Quaternion.identity, gameObject.transform);
                Vector3 destination = new Vector3(Random.Range(config.DUCK_LEFTMOST_POSITION, config.DUCK_RIGHTMOST_POSITION), y_value, 0);
                new_duck.GetComponent<Duck>().setDestination(destination);
                new_duck.GetComponent<Duck>().setAudioClip(quacks[Random.Range(0, 13)]);
                next_spawn = Random.Range(config.DUCK_SPAWN_MIN_INTERVAL, config.DUCK_SPAWN_MAX_INTERVAL);
            }
        }
    }

    public void enable(bool enabled)
    {
        this.enabled = enabled;
        if (!enabled)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.GetComponent<Duck>().disable();
            }
        }
    }

    public void despawn()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
