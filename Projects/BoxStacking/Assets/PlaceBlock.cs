using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlockStacking
{
    public class PlaceBlock : MonoBehaviour
    {
        public AudioSource audioData;
        public GameObject blockPrefab;
        public Text scoreText;
        public float placeDelay;
        public int score;

        private float nextPlace;
        private float scroll;
        // Start is called before the first frame update
        void Start()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {
            //scroll += Input.GetAxis("Mouse ScrollWheel");
            if (Input.GetButton("Fire1") && Time.time > nextPlace)
            {
                nextPlace = Time.time + placeDelay;
                Vector3 placeBlockPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                Instantiate(blockPrefab, placeBlockPosition, Quaternion.identity);
                score++;
                scoreText.text = "Score: " + score;
                audioData.PlayOneShot(audioData.clip, 1);
            }
            if (Input.GetButton("Cancel"))
            {
                Application.Quit();
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                scroll += 0.4f;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && scroll >= 0)
            {
                scroll -= 0.4f;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, scroll, transform.position.z), 0.25f);
        }
    }
}
