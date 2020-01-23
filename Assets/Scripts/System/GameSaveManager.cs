using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public Bag myBag;

    public void SaveGame()
    {
        //要存储的地址
        string savePath = Application.persistentDataPath + "/saveData";
        string bagFileSavePath = savePath + "/bagData.txt";

        //验证存储地址是否存在,若不存在则创建
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        //创建二进制化的格式
        BinaryFormatter bf = new BinaryFormatter();

        //创建流文件
        FileStream file = File.Create(bagFileSavePath);

        //创建一个临时变量存储数据
        var json = JsonUtility.ToJson(myBag);

        //将临时数据传输进目标文件(序列化)
        bf.Serialize(file, json);

        //提示成功并关闭流
        Debug.Log("Save successful in : " + bagFileSavePath);
        file.Close();
    }

    public void LoadGame()
    {
        //存储地址
        string bagFileSavePath = Application.persistentDataPath + "/saveData/bagData.txt";

        //二进制格式
        BinaryFormatter bf = new BinaryFormatter();

        //判断地址是否存在
        if (File.Exists(bagFileSavePath))
        {
            //使用流打开文件
            FileStream file = File.Open(bagFileSavePath, FileMode.Open);

            //反序列化
            string data = (string)bf.Deserialize(file);

            //使用json进行数据覆盖
            JsonUtility.FromJsonOverwrite(data, myBag);

            //输出成功提示兵关闭流
            Debug.Log("Load data successfully from : " + bagFileSavePath);
            file.Close();
        }
    }

}
