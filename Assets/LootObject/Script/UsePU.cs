using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using JetBrains.Annotations;

public class UsePU : MonoBehaviour
{
    public Coroutine coffeecoroutine;
    public Coroutine bandoliercoroutine;
    public Coroutine nukecoroutine;
    public Coroutine tombstonecoroutine;
    public Coroutine shotguncoroutine;
    public Coroutine badgecoroutine;
    public Coroutine smokebombcoroutine;

    [SerializeField] private Spawner spawnertop; 
    [SerializeField] private Spawner spawnerleft; 
    [SerializeField] private Spawner spawnerbot; 
    [SerializeField] private Spawner spawnerright; 
    [SerializeField] private GameObject lightning;
    [SerializeField] private GameObject TombstoneBackground;
    [SerializeField] private GameObject TimerUI;
    [SerializeField] private GameObject LootCanvas;
    [SerializeField] private GameObject leg;
    [SerializeField] private AudioController audiocontroller;
    [SerializeField] private Animator cbanim;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Gun gun;
    [SerializeField] private LootSlot lootslot;

    public bool IsUsingTombstone = false;
    public bool IsUsingShotgun = false;
    public bool IsUsingBadge = false;
    public bool IsUsingWheel = false;
    [SerializeField] private bool IsUsingCoffee = false;
    [SerializeField] private bool IsUsingBandolier = false;
    [SerializeField] private string currentstate;
    [SerializeField] private bool IsUsingSmokeBomb = false;

    const string DefaultState = "Default State";
    const string CBLightning = "CBLightning";
    const string CBZombie = "CBZombie";
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        audiocontroller = player.GetComponent<AudioController>();    
        cbanim = player.GetComponent<Animator>();

        spawnertop = GameObject.Find("SpawnerTop").GetComponent<Spawner>();
        spawnerleft = GameObject.Find("SpawnerLeft").GetComponent<Spawner>();
        spawnerbot = GameObject.Find("SpawnerBot").GetComponent<Spawner>();
        spawnerright = GameObject.Find("SpawnerRight").GetComponent<Spawner>();

        gun = FindObjectOfType<Gun>();   
        lootslot = FindObjectOfType<LootSlot>();
    }

    void Update()
    {
        if (lootslot.lootsprite == null) return;
        if (!Input.GetKey(KeyCode.Space)) return;
        if (lootslot.loottag == "Coffee")
        {
            if (coffeecoroutine != null)
            {
                StopCoroutine(coffeecoroutine);
                StopUsingCoffee();
            }
            coffeecoroutine = StartCoroutine(UsingCoffeee());
            audiocontroller.PU.Play();
        }
        else if (lootslot.loottag == "Bandolier")
        {
            if (bandoliercoroutine != null)
            {
                StopCoroutine(bandoliercoroutine);
                StopUsingBandolier();
            }
            bandoliercoroutine = StartCoroutine(UsingBandolier());
            audiocontroller.Gunload.Play();
        }
        else if (lootslot.loottag == "Nuke")
        {
            if (nukecoroutine != null) StopCoroutine(nukecoroutine);
            nukecoroutine = StartCoroutine(UsingNuke());
        }
        else if (lootslot.loottag == "Tombstone")
        {
            if (tombstonecoroutine != null)
            {
                StopCoroutine(tombstonecoroutine);
                StopUsingTombstone();
            }
            tombstonecoroutine = StartCoroutine(UsingTombstone());
            audiocontroller.OnTombstone();
        }
        else if (lootslot.loottag == "Shotgun")
        {
            if (shotguncoroutine != null)
            {
                StopCoroutine(shotguncoroutine);
                StopUsingShotgun();
            }
            shotguncoroutine = StartCoroutine(UsingShotgun());
            audiocontroller.Gunload.Play();
        }
        else if (lootslot.loottag == "Badge")
        {
            if (badgecoroutine != null)
            {
                StopCoroutine(badgecoroutine);
                StopUsingBadge();
            }
            badgecoroutine = StartCoroutine(UsingBadge());
            audiocontroller.Gunload.Play();
        }
        else if (lootslot.loottag == "Smoke bomb")
        {
            if (smokebombcoroutine != null)
            {
                StopCoroutine(smokebombcoroutine);
                StopUsingSmokeBomb();
            }
            smokebombcoroutine = StartCoroutine(UsingSmokeBomb());   
        }
        lootslot.OnUsed();    
    }
    //==========================CoffeePU==========================//
    private IEnumerator UsingCoffeee()
    {
        IsUsingCoffee = true;   
        player.MoveSpeed += 2f;
        player.MoveSpeed2 += 2f;

        yield return new WaitForSeconds(16f);

        IsUsingCoffee = false;
        player.MoveSpeed -= 2f;
        player.MoveSpeed2 -= 2f;
    }
    void StopUsingCoffee()
    {
        if (IsUsingCoffee)
        {
            player.MoveSpeed -= 2f;
            player.MoveSpeed2 -= 2f; 
            IsUsingCoffee = false;   
        }
    }
    public void CollidedCoffee()
    {
        if (coffeecoroutine != null)
        {
            StopUsingCoffee();
            StopCoroutine(coffeecoroutine);
        }
        coffeecoroutine = StartCoroutine(UsingCoffeee());
    }
    //==========================CoffeePU==========================//

    //==========================BandolierPU==========================//
    private IEnumerator UsingBandolier()
    {
        gun.FireRate = 0.065f;
        gun.Damage = 4;
        IsUsingBandolier = true;    

        yield return new WaitForSeconds(12);

        gun.FireRate = 0.35f;
        gun.Damage = 1;
        IsUsingBandolier = false;   
        
        if (IsUsingBadge) gun.FireRate = 0.095f; 
    }
    void StopUsingBandolier()
    {
        if (IsUsingBandolier)
        {
            gun.FireRate = 0.35f;
            gun.Damage = 1;
            IsUsingBandolier = false;

            if (IsUsingBadge) gun.FireRate = 0.095f;
        }
    }
    public void CollidedBandolier()
    {
        if (bandoliercoroutine != null)
        {
            StopUsingBandolier();
            StopCoroutine(bandoliercoroutine);
        }
        bandoliercoroutine = StartCoroutine(UsingBandolier());
    }
    //==========================BandolierPU==========================//
    
    //==========================NukePU==========================//
    private IEnumerator UsingNuke()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject zombie in zombies)
        {
            Zombie zombie1 = zombie.GetComponent<Zombie>();
            zombie1.OnNuke();
        }
        ParticleSystem particlesystem = GameObject.Find("NukeExplosion").GetComponent<ParticleSystem>();
        particlesystem.Play();
        audiocontroller.Nuke.Play();    
        yield return new WaitForSeconds(2);
    }
    public void CollidedNuke()
    {
        if (nukecoroutine != null)
        {
            StopCoroutine(nukecoroutine);
        }
        nukecoroutine = StartCoroutine(UsingNuke());    
    }
    //==========================NukePU==========================//

    //==========================TombstonePU==========================//
    private IEnumerator UsingTombstone()
    {
        if (IsUsingTombstone) yield break;

        ChangeAnim(CBLightning);
        IsUsingTombstone = true;
        lightning.SetActive(true);
        TombstoneBackground.SetActive(true);
        audiocontroller.IsTombstonePlaying = true;

        TimerUI.SetActive(false);
        LootCanvas.SetActive(false);
        leg.SetActive(false);
        player.enabled = false;
        gun.enabled = false;
        spawnertop.enabled = false;
        spawnerleft.enabled = false;
        spawnerbot.enabled = false;
        spawnerright.enabled = false;

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

        yield return new WaitForSeconds(2);

        ChangeAnim(CBZombie);
        lightning.SetActive(false);
        TombstoneBackground.SetActive(false);

        TimerUI.SetActive(true);
        LootCanvas.SetActive(true);
        player.enabled = true;
        player.MoveSpeed += 2.5f;
        player.MoveSpeed2 += 2.5f;
        gun.enabled = true;

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

        yield return new WaitForSeconds(8.5f);

        IsUsingTombstone = false;
        if (player.isMoving == false && gun.isShooting == false)
        {
            ChangeAnim(DefaultState);
        }
        audiocontroller.IsTombstonePlaying = false;

        leg.SetActive(true);
        spawnertop.enabled = true;
        spawnerleft.enabled = true;
        spawnerbot.enabled = true;
        spawnerright.enabled = true;

        player.MoveSpeed -= 2.5f;
        player.MoveSpeed2 -= 2.5f;

        foreach (AIDestinationSetter destinationsetter in destinationsetters)
        {
            destinationsetter.target = player.transform;
        }
        foreach (AIPath aipath in aipaths) aipath.maxSpeed = 2;
    }

    void StopUsingTombstone()
    {
        if (IsUsingTombstone) 
        {
            IsUsingTombstone = false;
            audiocontroller.IsTombstonePlaying = false;
            lightning.SetActive(false);
            TombstoneBackground.SetActive(false);

            TimerUI.SetActive(true);
            LootCanvas.SetActive(true);
            player.enabled = true;
            gun.enabled = true;
            leg.SetActive(true);
            spawnertop.enabled = true;
            spawnerleft.enabled = true;
            spawnerbot.enabled = true;
            spawnerright.enabled = true;

            player.MoveSpeed -= 2.5f;
            player.MoveSpeed2 -= 2.5f;

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject zombie in zombies)
            {
                AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
                Seeker seeker = zombie.GetComponent<Seeker>();  
                AIPath aipath = zombie.GetComponent<AIPath>();
                if (destinationsetter != null) destinationsetter.target = player.transform;
                if (seeker != null) seeker.enabled = true;
                if (aipath != null) aipath.maxSpeed = 2;
            }
        }
    }
    public void CollidedTombstone()
    {
        if (tombstonecoroutine != null)
        {
            StopCoroutine(tombstonecoroutine);
            StopUsingTombstone();
        }
        tombstonecoroutine = StartCoroutine(UsingTombstone());
    }
    //==========================TombstonePU==========================//

    //==========================ShotgunPU==========================//
    private IEnumerator UsingShotgun()
    {
        IsUsingShotgun = true;
        gun.Damage = 4;

        if (IsUsingBandolier) gun.FireRate = 0.065f;

        yield return new WaitForSeconds(12f);

        IsUsingShotgun = false;
        gun.Damage = 1;

        if (!IsUsingBandolier) gun.FireRate = 0.35f;
    }
    void StopUsingShotgun()
    {
        if (IsUsingShotgun)
        {
            IsUsingShotgun = false;
            gun.Damage = 1;

            if (!IsUsingBandolier) gun.FireRate = 0.35f;
        }
    }
    public void CollidedShotgun()
    {
        if (shotguncoroutine != null)
        {
            StopCoroutine(shotguncoroutine);    
            StopUsingShotgun(); 
        }
        shotguncoroutine = StartCoroutine(UsingShotgun());  
    }
    //==========================ShotgunPU==========================//

    //==========================BadgePU==========================//
    private IEnumerator UsingBadge()
    {
        IsUsingBadge = true;
        gun.Damage = 4;
        gun.FireRate = 0.095f;

        if (IsUsingBandolier) gun.FireRate = 0.065f;
        
        player.MoveSpeed += 1.25f;
        player.MoveSpeed2 += 1.25f;

        yield return new WaitForSeconds(24f);

        IsUsingBadge = false;
        gun.Damage = 1;
        gun.FireRate = 0.35f;

        if (IsUsingBandolier) gun.FireRate = 0.065f; //Check if bandolier is still in used
        
        player.MoveSpeed -= 1.25f;
        player.MoveSpeed2 -= 1.25f;
    }
    void StopUsingBadge()
    {
        if (IsUsingBadge)
        {
            IsUsingBadge = false;
            gun.Damage = 1;
            gun.FireRate = 0.35f;
            if (IsUsingBandolier) gun.FireRate = 0.065f;
            player.MoveSpeed -= 1.25f;
            player.MoveSpeed2 -= 1.25f;
        }
    }
    public void CollidedBadge()
    {
        if (badgecoroutine != null) 
        {
            StopCoroutine(badgecoroutine); 
            StopUsingBadge();
        }
        badgecoroutine = StartCoroutine(UsingBadge());
    }
    //==========================BadgePU==========================//

    //==========================WheelPU==========================//
    private IEnumerator UsingWheel()
    {
        IsUsingWheel = true;

        yield return new WaitForSeconds(12f);

        IsUsingWheel = true;
    }
    //==========================WheelPU==========================//

    //==========================SmokeBombPU==========================//

    //Max horitonztal: 9.5 , -5,4
    //Max vertical: 6.4 , -8.4 
    private IEnumerator UsingSmokeBomb()
    {
        IsUsingSmokeBomb = true;    
        gameObject.transform.position = new Vector2(Random.Range(-5, 10), Random.Range(-8, 7));
        ParticleSystem particlesystem = GameObject.Find("NukeExplosion").GetComponent<ParticleSystem>();
        particlesystem.Play();
        audiocontroller.Nuke.Play();

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        List<Transform> transforms = new List<Transform>();
        List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();    
        List<AIDestinationSetter> destinationsetters = new List<AIDestinationSetter>();
        List<Seeker> seekers = new List<Seeker>();
        List<AIPath> aipaths = new List<AIPath>();

        foreach (GameObject zombie in zombies)
        {
            Transform zombietransform = zombie.transform;
            Rigidbody2D rigidbody2D = zombie.GetComponent<Rigidbody2D>();
            AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
            Seeker seeker = zombie.GetComponent<Seeker>();
            AIPath aipath = zombie.GetComponent<AIPath>();
            if (zombietransform != null)
            {
                Debug.Log(zombietransform.position);
            }
            if (rigidbody2D != null)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Static;
                rigidbody2Ds.Add(rigidbody2D);
            }
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

        yield return new WaitForSeconds(2);
        
        IsUsingSmokeBomb = false;

        foreach (GameObject zombie in zombies)
        {
            Rigidbody2D rigidbody2D = zombie.GetComponent<Rigidbody2D>();
            AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
            Seeker seeker = zombie.GetComponent<Seeker>();
            AIPath aipath = zombie.GetComponent<AIPath>();
            if (rigidbody2D != null)
            {
                rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                rigidbody2Ds.Add(rigidbody2D);
            }
            if (destinationsetter != null)
            {
                destinationsetter.enabled = true; // Disable AIDestinationSetter
                destinationsetters.Add(destinationsetter);
            }
            if (seeker != null)
            {
                seeker.enabled = true; // Disable Seeker
                seekers.Add(seeker);
            }
            if (aipath != null)
            {
                aipath.enabled = true; // Disable AIPath
                aipaths.Add(aipath);
            }
        }
    }

    public void StopUsingSmokeBomb()
    {
        if (IsUsingSmokeBomb)
        {
            IsUsingSmokeBomb = false;

            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
            List<Transform> transforms = new List<Transform>(); 
            List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();
            List<AIDestinationSetter> destinationsetters = new List<AIDestinationSetter>();
            List<Seeker> seekers = new List<Seeker>();
            List<AIPath> aipaths = new List<AIPath>();

            foreach (GameObject zombie in zombies)
            {
                Rigidbody2D rigidbody2D = zombie.GetComponent<Rigidbody2D>();
                AIDestinationSetter destinationsetter = zombie.GetComponent<AIDestinationSetter>();
                Seeker seeker = zombie.GetComponent<Seeker>();
                AIPath aipath = zombie.GetComponent<AIPath>();

                if (rigidbody2D != null)
                {
                    rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    rigidbody2Ds.Add(rigidbody2D);
                }
                if (destinationsetter != null)
                {
                    destinationsetter.enabled = true; 
                    destinationsetters.Add(destinationsetter);
                }
                if (seeker != null)
                {
                    seeker.enabled = true; 
                    seekers.Add(seeker);
                }
                if (aipath != null)
                {
                    aipath.enabled = true; 
                    aipaths.Add(aipath);
                }
            }
        }
    }

    void ChangeAnim(string newstate)
    {
        if (currentstate == newstate) return;
        cbanim.Play(newstate);
        currentstate = newstate;    
    }
}
