using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrandpaVisit
{
    public class JsonConverter : MonoBehaviour
    {
        
        private void Start()
        {
            //test
            var test = new Block();
            test.id = "test";
            test.headline = "test headline";
            test.text = "test text";
            test.options = new Option[2];
            // Initialize each element of the array
            test.options[0] = new Option();
            test.options[1] = new Option();
            
            
            test.options[0].text = "test option 1";
            test.options[1].text = "test option 2";
            test.options[0].followup = "test option 1 next block";
            
            var json = ObjectToJson(test);
            // Save json to file
            
            
            Debug.Log(json);
            
            var obj = JsonToObject<Block>(json);
            Debug.Log("Object   :  " + obj.id + " : " + obj.headline + " : " + obj.text + " : " + 
                      obj.options[0].text + " : " + obj.options[1].text + " : " + obj.options[0].followup);
        }
        
        //convert json to object
        public static T JsonToObject<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
        
        
        //convert object to json
        public static string ObjectToJson<T>(T obj)
        {
            return JsonUtility.ToJson(obj);
        }
    }
}
