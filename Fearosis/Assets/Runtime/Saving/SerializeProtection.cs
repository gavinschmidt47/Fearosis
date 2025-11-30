using UnityEngine;

public class SerializeProtection : MonoBehaviour
{
    protected int key = 06162004;

    public byte[] Protect(string data)
    {
        byte[] protectedData = System.Text.Encoding.UTF8.GetBytes(data);
        for (int i = 0; i < protectedData.Length; i++)
        {
            protectedData[i] ^= (byte)key;
        }
        return protectedData;
    }
}
