using UnityEngine;

public class TargetsManager : MonoBehaviour
{
    public TargetsAbstract[] Targets = new TargetsAbstract[4];
    public float __delayBetweenSpawns = 1f;
    public Transform GuitarCanvas;
    private Vector3[] TargetPosition = new Vector3[4];
    private bool __isSpawning = false;
    private float __timer = 0;
    private WinCondition __winCondition;
    private void Awake()
    {
        for (int i = 0; i < TargetPosition.Length; i++)
        {
            TargetPosition[i] = Targets[i].transform.localPosition;           
        }
        __winCondition = GetComponent<WinCondition>();
    }
    public void StartTargetsSpawn()
    {
        __isSpawning = true;
    }
    public void StopTargetsSpawn()
    {
        __isSpawning = false;
    }
    private void FixedUpdate()
    {
        if (__isSpawning)
        {
            if (__timer > __delayBetweenSpawns)
            {
                int __randomNumber = Random.Range(0, 4);
                TargetsAbstract __temp = Instantiate(Targets[__randomNumber]);

                __temp.transform.SetParent(GuitarCanvas);
                __temp.transform.localPosition = TargetPosition[__randomNumber];
                __temp.transform.localScale = new Vector3(1, 1, 1);

                __temp.SetWinCodition(__winCondition);

                __timer = 0;
            }
            __timer += Time.fixedDeltaTime;
        }
    }
}
