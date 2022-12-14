using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Aiming aiming;
    public BackGround background;
    public AsteroidSpawner spawner;
    public ParticleSystem explosion;
    public float respawnTime = 2.0f;
    public int lives = 3;
    public float respawnInvulnerabilityTime = 3.0f;
    public int score = 0;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75f)
        {
            score += 100;
        }
        else if (asteroid.size < 1.25f)
        {
            score += 50;
        }
        else
        {
            score += 25;
        }
    }

    public void PillPicked(Pill pill)
    {
        background.ChangeDruggedBG();
        this.explosion.transform.position = pill.transform.position;
        this.explosion.Play();

        lives++;
        aiming.buff = true;
        spawner.spawnAmount = 6;
        spawner.spawnRate = 0.1f;
    }

    public void RemoveBuff()
    {
        background.ChangeRegularBG();
        aiming.buff = false;
        spawner.spawnAmount = 1;
        spawner.spawnRate = 1.5f;
    }

    public void PlayerDied()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }

        //player.animator.SetBool("death", false);
    }

    private void Respawn()
    {
        background.ChangeRegularBG();
        RemoveBuff();
        player.GetComponent<BoxCollider2D>().enabled = true;
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        background.ChangeGameoverBG();
        lives = 3;
        score = 0; 
        
        Invoke(nameof(Respawn), this.respawnTime);
    }
}
