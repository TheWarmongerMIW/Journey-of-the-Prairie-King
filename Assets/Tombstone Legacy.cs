using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombstoneLegacy : MonoBehaviour
{
    public Coroutine coffeecoroutine;
    public Coroutine bandoliercoroutine;
    public Coroutine tombstonecoroutine;
    public Coroutine nukecoroutine;
    public GameObject lightning;
    public GameObject TombstoneBackground;
    public GameObject TimerUI;
    public GameObject LootCanvas;
    public GameObject Leg;
    public Animator cbanimator;
    public AudioController audiocontroller;
    [SerializeField] private LootSlot lootslot;
    public bool IsUsingTombstone = false;
    //[SerializeField] private bool IsUsingCoffee = false;
    //[SerializeField] private bool IsUsingBandolier = false;

    void Start()
    {
        lootslot = GameObject.Find("LootSlot").GetComponent<LootSlot>();
        audiocontroller = GameObject.Find("Player").GetComponent<AudioController>();
    }

    //==========================TombstonePU==========================//
    private IEnumerator UsingTombstone()
    {
        PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Spawner spawnertop = GameObject.Find("SpawnerTop").GetComponent<Spawner>();
        Spawner spawnerleft = GameObject.Find("SpawnerLeft").GetComponent<Spawner>();
        Spawner spawnerbot = GameObject.Find("SpawnerBot").GetComponent<Spawner>();
        Spawner spawnerright = GameObject.Find("SpawnerRight").GetComponent<Spawner>();

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        List<AIDestinationSetter> destinationsetters = new List<AIDestinationSetter>();
        List<Seeker> seekers = new List<Seeker>();
        List<AIPath> aipaths = new List<AIPath>();

        foreach (GameObject zombie in zombies)
        {
            AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
            Seeker seeker = zombie.GetComponent<Seeker>();
            AIPath aipath = zombie.GetComponent<AIPath>();
            if (destinationsetter != null)
            {
                destinationsetter.enabled = false; // Disable AIDestinationSetter
                destinationsetters.Add(destinationsetter);
            }
            if (seeker != null)
            {
                seeker.enabled = false; // Disable Seeker
                seekers.Add(seeker);
            }
            if (aipath != null)
            {
                aipath.enabled = false; // Disable AIPath
                aipaths.Add(aipath);
            }
        }

        player.enabled = false;
        IsUsingTombstone = true;
        audiocontroller.IsTombstonePlaying = true;
        spawnertop.enabled = false;
        spawnerleft.enabled = false;
        spawnerbot.enabled = false;
        spawnerright.enabled = false;
        TimerUI.SetActive(false);
        LootCanvas.SetActive(false);
        lightning.SetActive(true);
        Leg.SetActive(false);
        TombstoneBackground.SetActive(true);
        cbanimator.SetTrigger("TombstonePU");

        yield return new WaitForSeconds(2);

        foreach (AIDestinationSetter destinationsetter in destinationsetters)
        {
            destinationsetter.enabled = true;
            int randomnumber = UnityEngine.Random.Range(1, 5);
            if (randomnumber == 1) destinationsetter.target = spawnertop.transform;
            if (randomnumber == 2) destinationsetter.target = spawnerleft.transform;
            if (randomnumber == 3) destinationsetter.target = spawnerbot.transform;
            if (randomnumber == 4) destinationsetter.target = spawnerright.transform;
        }
        foreach (Seeker seeker in seekers) seeker.enabled = true;
        foreach (AIPath aipath in aipaths)
        {
            aipath.enabled = true;
            aipath.maxSpeed = 2.5f;
        }

        player.enabled = true;
        player.MoveSpeed += 2.5f;
        player.MoveSpeed2 += 2.5f;
        TimerUI.SetActive(true);
        LootCanvas.SetActive(true);
        lightning.SetActive(false);
        TombstoneBackground.SetActive(false);
        Leg.SetActive(false);
        cbanimator.SetTrigger("TombstoneZB");
        cbanimator.ResetTrigger("TombstonePU");
        cbanimator.ResetTrigger("LookUp");
        cbanimator.ResetTrigger("LookLeft");
        cbanimator.ResetTrigger("LookDown");
        cbanimator.ResetTrigger("LookRight");

        yield return new WaitForSeconds(8.5f);

        foreach (AIDestinationSetter destinationsetter in destinationsetters)
        {
            destinationsetter.target = player.transform;
        }
        foreach (AIPath aipath in aipaths) aipath.maxSpeed = 2;

        IsUsingTombstone = false;
        audiocontroller.IsTombstonePlaying = false;
        spawnertop.enabled = true;
        spawnerleft.enabled = true;
        spawnerbot.enabled = true;
        spawnerright.enabled = true;
        player.MoveSpeed -= 2.5f;
        player.MoveSpeed2 -= 2.5f;
        Leg.SetActive(true);
        cbanimator.SetTrigger("FinishedUsingTombstone");
        cbanimator.ResetTrigger("TombstoneZB");
    }
    public void StopUsingTombstone()
    {
        if (IsUsingTombstone)
        {
            StopCoroutine(tombstonecoroutine);

            PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
            Spawner spawnertop = GameObject.Find("SpawnerTop").GetComponent<Spawner>();
            Spawner spawnerleft = GameObject.Find("SpawnerLeft").GetComponent<Spawner>();
            Spawner spawnerbot = GameObject.Find("SpawnerBot").GetComponent<Spawner>();
            Spawner spawnerright = GameObject.Find("SpawnerRight").GetComponent<Spawner>();

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject zombie in zombies)
            {
                AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
                Seeker seeker = zombie.GetComponent<Seeker>();
                AIPath aipath = zombie.GetComponent<AIPath>();
                if (destinationsetter != null)
                {
                    destinationsetter.enabled = true;
                    destinationsetter.target = player.transform;
                }
                if (seeker != null) seeker.enabled = true;
                if (aipath != null)
                {
                    aipath.enabled = true;
                    aipath.maxSpeed = 2;
                }
            }

            player.enabled = true;
            player.MoveSpeed -= 2.5f;
            player.MoveSpeed2 -= 2.5f;
            TimerUI.SetActive(true);
            LootCanvas.SetActive(true);
            lightning.SetActive(false);
            TombstoneBackground.SetActive(false);
            Leg.SetActive(true);
            spawnertop.enabled = true;
            spawnerleft.enabled = true;
            spawnerbot.enabled = true;
            spawnerright.enabled = true;

            IsUsingTombstone = false;
            audiocontroller.IsTombstonePlaying = false;
        }
    }
    public void CollidedTombstone()
    {
        if (tombstonecoroutine != null)
        {
            StopCoroutine(UsingTombstone());
            StopUsingTombstone();
        }
        tombstonecoroutine = StartCoroutine(UsingTombstone());
    }
    //==========================TombstonePU==========================//
}
