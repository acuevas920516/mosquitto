using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour

{
       bool up=false;
	   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
            FindObjectOfType<mqttTest>().sendAction("left");
            //FindObjectOfType<mqttTest>().sendPosition(position.x, position.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
            FindObjectOfType<mqttTest>().sendAction("right");
            //FindObjectOfType<mqttTest>().sendPosition(position.x, position.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)|| up)
        {
			up=false;
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
            FindObjectOfType<mqttTest>().sendAction("up");
            //FindObjectOfType<mqttTest>().sendPosition(position.x, position.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;

            FindObjectOfType<mqttTest>().sendAction("down");
            //FindObjectOfType<mqttTest>().sendPosition(position.x, position.y);

        }
    }
	
	public void goUp(){
		this.up=true;
	}
}