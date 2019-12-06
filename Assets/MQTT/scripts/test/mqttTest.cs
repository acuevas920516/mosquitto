using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;

public class mqttTest : MonoBehaviour {
	private MqttClient client;
    private MyTileMapEvent map;
	private Movement person;
    // Use this for initialization
    void Start () {
		// create client instance 
		client = new MqttClient(IPAddress.Parse("127.0.0.1"), 1883, false , null ); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
		// subscribe to the topic "/world" with QoS 2 
		client.Subscribe(new string[] { "map" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		
        map = FindObjectOfType<MyTileMapEvent>();
		person = FindObjectOfType<Movement>();
    }
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{
        string msg = System.Text.Encoding.UTF8.GetString(e.Message);
        if(e.Topic == "map")
        {
            map.paintSomething();
        }
        
        //Debug.Log("Received: " + msg+" from "+e.Topic);

        //if (msg == "clear")
        //{
            //Debug.Log("Clear!");
            //map.removeSomething();
        //}else if (msg == "up"){
			//person.goUp();
		//}
        //else
            //map.paintSomething();
    } 

	void OnGUI(){
		if ( GUI.Button (new Rect (20,40,80,20), "Level 1")) {
			Debug.Log("sending...");
			client.Publish("action/", System.Text.Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
	}
	// Update is called once per frame
	void Update () {



	}
    public void sendPosition(float x, float y)
    {
       
            Debug.Log("sending...");
            client.Publish("user/position", System.Text.Encoding.UTF8.GetBytes("posx:"+x+",posy:"+y), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Debug.Log("sent");
     
    }

    public void sendAction(string action)
    {
        Debug.Log("sending...");
        client.Publish("action/"+action, System.Text.Encoding.UTF8.GetBytes("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        Debug.Log("sent");
    }
}
