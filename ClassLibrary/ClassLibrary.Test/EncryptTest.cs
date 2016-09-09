using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClassLibrary;

namespace ClassLibrary.Test
{
    [TestFixture]
    class EncryptTest
    {
        [TestCase("ASDFGHJKLÑ")]
        [TestCase("LAUREATE INTERNATIONAL UNIVERSITIES")]
        public void Encrypt_Encrypt_ReturnDataEncrypted(string data)
        {
            Encrypt encrypt = new Encrypt();
            string dataEncrypted = encrypt.encryptData(data);

            Console.WriteLine(dataEncrypted);
        }

        [TestCase("hHeKw3V54pvY3aYX8490zg==", "ASDFGHJKLÑ")]
        [TestCase("OsTpUBzUugIKmVIYROVgLwPywjDKQwDgWXrLrt7mW8o+6VnJAxm/dA==", "LAUREATE INTERNATIONAL UNIVERSITIES")]
        public void Encrypt_Decrypt_ReturnDataDecripted(string encriptedData, string decryptedData)
        {
            Encrypt encrypt = new Encrypt();
            string decryptedDataResult = encrypt.decryptData(encriptedData);
            Assert.AreEqual(decryptedDataResult, decryptedData);

            Console.WriteLine(decryptedDataResult);
        }
    }
}
