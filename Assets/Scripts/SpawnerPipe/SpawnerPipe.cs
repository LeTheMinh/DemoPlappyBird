using System.Collections;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Spawner());
    }
    IEnumerator Spawner()// delay_action
    {
        yield return new WaitForSeconds(1);

        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2f, 2f);
        Instantiate(pipeHolder, temp, Quaternion.identity);//tao ban sao
        StartCoroutine(Spawner());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
