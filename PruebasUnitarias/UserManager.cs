using MF0493_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
     [TestClass]
    class UserManager
    {
        /// <summary>
        /// Testea el metodo getAll de la clase UserManager. Comprobamos que el numero de resultados obtenidos se incrementa en uno al insertar. Y baja en uno al eliminar.
        /// </summary>
        [TestMethod]
        public void getAllTest()
        {
            List<Usuario> lista = UserManager.getAll();
            int numero = lista.Count;

            Usuario c = new Usuario();
            c.username = "nector";
            c.email = "nectorosales@gmail.com";
            c.passwd = "aaa111...";
            int id = UserManager.Add(c);

            lista = UserManager.getAll();
            int numero2 = lista.Count;
            Assert.AreEqual(numero + 1, numero2);

            bool elimina = UserManager.Remove(id);
            lista = UserManager.getAll();
            int numero3 = lista.Count;
            Assert.AreEqual(numero, numero3);
        }

        /// <summary>
        /// Testea el metodo remove de la clase CouseManager. Comprueba que el metodo devuelve true al eliminar. Antes se crea un curso, para poder borrarlo y que no altere la base de datos.
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            Usuario c = new Usuario();
            c.username = "nector";
            c.email = "nectorosales@gmail.com";
            c.passwd = "aaa111...";
            int id = UserManager.Add(c);

            bool elimina = UserManager.Remove(id);
            Assert.AreEqual(elimina, true);
        }
    }
}
