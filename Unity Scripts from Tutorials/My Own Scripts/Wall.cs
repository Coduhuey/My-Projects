using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public Sprite dmgSprite; //sprite of damaged wall
    public int hp = 4;

    public AudioClip damagewall1;
    public AudioClip damagewall2; //placement of these variables depends on the location of the functions that will use them

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;

        SoundManager.instance.RandomizeSfx(damagewall1, damagewall2);

        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
