using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        //Gets the world position of the mouse on the screen        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var tapCount = Input.touchCount;
        var touch1 = new Touch();
        var touch2 = new Touch();
        if (tapCount > 1)
        {
            touch1 = Input.GetTouch(0);
            touch2 = Input.GetTouch(1);
            Vector2 newDirection;
            if (this.transform.position.y > 0 && Camera.main.ScreenToWorldPoint(touch1.position).y > 0)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(touch1.position);
            } else if (this.transform.position.y > 0 && Camera.main.ScreenToWorldPoint(touch2.position).y > 0)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(touch2.position);
            }
            else if (this.transform.position.y < 0 && Camera.main.ScreenToWorldPoint(touch2.position).y < 0)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(touch2.position);
            } else if (this.transform.position.y < 0 && Camera.main.ScreenToWorldPoint(touch1.position).y < 0)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(touch1.position);
            }
            else {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (tapCount == 1)
        {
                touch1 = Input.GetTouch(0);
                mousePosition = Camera.main.ScreenToWorldPoint(touch1.position);
                //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        } else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


        //Checks whether the mouse is over the sprite
        //bool overSprite = this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition);

        //If it's over the sprite
        //if (overSprite)
        {
            //If we've pressed down on the mouse (or touched on the iphone)
            if (this.gameObject.name == "player1" || this.gameObject.name == "player2" )
            {
                //Set the position to the mouse position
                if (mousePosition.y > 0 && this.gameObject.name == "player2")
                {
                    this.transform.position = new Vector3(mousePosition.x,
                                                        this.transform.position.y,
                                                          0.0f);
                } else if (mousePosition.y < 0 && this.gameObject.name == "player1") {
                    this.transform.position = new Vector3(mousePosition.x,
                                                        this.transform.position.y,
                                                          0.0f);

                }
            }
        }



    }
}