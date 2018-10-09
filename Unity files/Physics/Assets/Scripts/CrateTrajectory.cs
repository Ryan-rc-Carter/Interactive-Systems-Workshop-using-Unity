using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ISS
{

    public class CrateTrajectory : MonoBehaviour {

        public GameObject dotPrefab;
        private Camera mainCamera;

        [SerializeField]
        private GameObject[] arrayDots;
        private Vector3 direction;
        public float force = 10.0f;
        public float gravity = -9.81f;

        // Use this for initialization
        void Start() {

            mainCamera = Camera.main;

            arrayDots = new GameObject[10];

            for (int i = 0; i < arrayDots.Length; i++)
            {
                GameObject tempObject = Instantiate(dotPrefab);

                arrayDots[i] = tempObject;
                arrayDots[i].SetActive(false);
            }

        }

        // Update is called once per frame
        void Update() {

            if (Input.GetMouseButton(0))
            {
                Vector3 screenPos = mainCamera.ScreenToWorldPoint(transform.position);

                screenPos.z = 0;

                direction = (Input.mousePosition - screenPos).normalized;

                Aim();
            }



        }

        private void Aim()
        {


            float Sx = -direction.x * force;
            float Sy = -direction.y * force;

            for (int i = 0; i < arrayDots.Length; i++)
            {
                float t = i * 0.5f;

                float Dx = transform.position.x + Sx * t;
                float Dy = transform.position.y + Sy * t - 0.5f - gravity * (t * t);

                Vector3 newPosition = new Vector3(Dx, Dy);

                arrayDots[i].transform.position = newPosition;
                arrayDots[i].SetActive(true);
            }



        }
    }
}