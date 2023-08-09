using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using System.Text;
using System;

public class MQTT_Subscribe : MonoBehaviour
{
    private MqttClient mqttClient;
    private string brokerAddress = "210.119.12.112"; // MQTT BROKER IP
    private int brokerPort = 11000;
    private string s_topic = "TEAM_ONE/parking/Sensor_data/"; // 구독할 토픽

    // Start is called before the first frame update
    void Start()
    {
        mqttClient = new MqttClient(brokerAddress, brokerPort, false, null, null, MqttSslProtocols.None);
        mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
        mqttClient.Connect(Guid.NewGuid().ToString());
        mqttClient.Subscribe(new string[] { s_topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    private void OnApplicationQuit()
    {
        if( mqttClient.IsConnected )
            mqttClient.Disconnect();
    }

    private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        try
        {
            // MQTT 메시지 수신 이벤트 처리
            string message = Encoding.UTF8.GetString(e.Message);
            //JSON 데이터 파싱
            EventManager.Instance.Sensor_Data = JsonConvert.DeserializeObject<SensorData>(message);

            //EventManager.Instance.

            ////데이터를 EventManager에 저장
            //EventManager.Instance.SensorData.AD1_RCV_IR_Sensor = data.AD1_RCV_IR_Sensor;
            //EventManager.Instance.SensorData.AD1_RCV_Temperature = data.AD1_RCV_Temperature;
            //EventManager.Instance.SensorData.AD1_RCV_Humidity = data.AD1_RCV_Humidity;
            //EventManager.Instance.SensorData.AD1_RCV_Dust = data.AD1_RCV_Dust;
            //EventManager.Instance.SensorData.AD1_RCV_Parking_Status = data.AD1_RCV_Parking_Status;
            //EventManager.Instance.SensorData.AD2_RCV_CGuard = data.AD2_RCV_CGuard;
            //EventManager.Instance.SensorData.AD3_RCV_WGuard_Wave = data.AD3_RCV_WGuard_Wave;
            //EventManager.Instance.SensorData.AD4_RCV_NFC = data.AD4_RCV_NFC;
            //EventManager.Instance.SensorData.AD4_RCV_WL_CNNT = data.AD4_RCV_WL_CNNT;
        }
        catch(Exception ex)
        {
            Debug.Log($"{ex}");
        }
    }
}
