using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Hello World");
            //Log is a static function in the Debug class
            //In C++ it would look like Debug::Log        
        print("Goodbye World"); 
    }

    // Update is called once per frame
    // this - points to the SCRIPT being called
    // gameObject - refers to the gameobject a script is attached to
    // GameObject - the base class for all objects in Unity that you can drop in the editor (Actor in Unreal)
    // In C# all class objects are called References (like pointer)

    //GameObject obj = gameObject; - 1 object, 1 pointer to the object
   // GameObject obj2 = new GameObject(gameObject);//2 objects (invalid code, just a demonstration)
   // In c#, you use new to create new objects, and you don't have to use delete.
   // C# has these things called 'Properties'
    //A Property is like a variable + a get and set function wrapped into one.

    //Update - Every Frame
    //FixedUpdate - Every Physics Engine Tick 
    void FixedUpdate ()
    {
        //For storing coordinates in 3D, games use Vectors
        //A Vector3 is just 3 float values - X, Y and Z

        //GetKey = When key is held down (continuous)
        //GetKeyDown = When key is FIRST pressed (1 frame)
        //These seem totally backwards, but I didn't write Unity :(

        if (Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.position.x += 10;//Can't do it this way
            gameObject.transform.position += new Vector3(.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        { 
            gameObject.transform.position += new Vector3(-.1f, 0, 0);
        }
    }
}
