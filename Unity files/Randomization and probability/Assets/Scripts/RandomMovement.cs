using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    private Transform cubeTransform;

    private int randomNumber;

    private float randomFloat;

    private int[] intArray;

    private float randomMoveDistance;


    [SerializeField]
    private AnimationCurve cubeAnimation;



    

	// Use this for initialization
	void Start () {

        cubeTransform = transform;

        
		
	}
	
	// Update is called once per frame
	void Update () {

        //Step();

        //StepArray();

        //StepPercentage();


        //stepCurve();

        stepVector();

    }


    private void stepVector()
    {
        float randomX = Random.Range(-1.0f, 1.0f);

        float randomZ = Random.Range(-1.0f, 1.0f);


        cubeTransform.position += new Vector3(randomX, 0.0f, randomZ);
    }


    private void stepCurve()
    {
        float randomCurveValue = Random.Range(0.0f, 1.0f);
        float randomFloat = cubeAnimation.Evaluate(randomCurveValue);

        float stepX = 0;
        float stepZ = 0;


        if (randomFloat < 0.25)
        {
            //forward

            stepX = -0.1f;


        }
        else if (randomFloat < 0.50)
        {
            //backwards

            stepX = 0.1f;
        }
        else if (randomFloat < 0.75)
        {
            //left

            stepZ = -0.1f;
        }
        else
        {
            stepZ = 0.1f;
        }

        cubeTransform.position += new Vector3(stepX, 0.0f, stepZ);


    }
    private void StepPercentage()
    {

        randomFloat = Random.Range(0.0f, 1.0f);

        float stepX = 0;
        float stepZ = 0;


        if (randomFloat < 0.85)
        {
            //forward

            stepX = -0.1f;


        }
        else if (randomFloat < 0.15)
        {
            //backwards

            stepX = 0.1f;
        }
        else if (randomFloat < 0.10)
        {
            //left

            stepZ = -0.1f;
        }
        else 
        {
            stepZ = 0.1f;
        }

        cubeTransform.position += new Vector3(stepX, 0.0f, stepZ);


    }



    private void StepArray()
    {
        intArray = new int[5];

        intArray[0] = 0;

        intArray[1] = 1;

        intArray[2] = 2;

        intArray[3] = 3;

        intArray[4] = 0;


        int randomIndex = Random.Range(0, 4);

        float stepX = 0;
        float stepZ = 0;

        randomNumber = intArray[randomIndex];

        randomMoveDistance = Random.Range(0.1f, 0.5f);


        if (randomNumber == 0)
        {
            //forward

            stepX = -randomMoveDistance;


        }
        else if (randomNumber == 1)
        {
            //backwards

            stepX = randomMoveDistance;
        }
        if (randomNumber == 2)
        {
            //left

            stepZ = -randomMoveDistance;
        }
        else if (randomNumber == 3)
        {
            stepZ = randomMoveDistance;
        }



        cubeTransform.position += new Vector3(stepX, 0.0f, stepZ);


    }

    private void Step()
    {
        randomNumber = Random.Range(0, 4);

        float stepX = 0;
        float stepZ = 0;



        if (randomNumber == 0)
        {
            //forward

            stepX = -0.1f;


        }
        else if (randomNumber == 1)
        {
            //backwards

            stepX = 0.1f;
        }
        if (randomNumber == 2)
        {
            //left

            stepZ = -0.1f;
        }
        else if (randomNumber == 3)
        {
            stepZ = 0.1f;
        }

        /*switch (randomNumber)
        {
            case (0):
                stepX = -0.1f;
                break;
            case (1):
                stepX = 0.1f;
                break;
            case (2):
                stepZ = -0.1f;
                break;
            case (3):
                stepZ = 0.1f;
                break;

        }*/


        cubeTransform.position += new Vector3(stepX, 0.0f, stepZ);

    }
}
