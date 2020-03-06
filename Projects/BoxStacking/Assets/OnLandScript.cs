using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockStacking
{
    public class OnLandScript : MonoBehaviour
    {
        public AudioSource audioData;
        public AudioClip OnLandGround;
        public AudioClip OnLandCrate;

        private bool hitGround;
        private Rigidbody2D rb;
        private PlaceBlock placeBlock;

        // Start is called before the first frame update
        void Start()
        {
            hitGround = false;

            rb = this.GetComponent<Rigidbody2D>();

            GameObject player = GameObject.Find("Main Camera");
            placeBlock = player.GetComponent<PlaceBlock>();
            audioData = GetComponent<AudioSource>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (this.transform.position.y >= -3)
            {
                audioData.PlayOneShot(OnLandCrate, 0.3f);
            }
        }

            // Update is called once per frame
            void Update()
        {
            if (hitGround == false && rb.velocity.y == 0.0)
            {
                if (this.transform.position.y < -3)
                {
                    hitGround = true;
                    placeBlock.score--;
                    placeBlock.scoreText.text = "Score: " + placeBlock.score;
                    audioData.clip = OnLandGround;
                    audioData.Play();
                }
            }
        }
    }
}
