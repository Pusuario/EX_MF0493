using MF0493_3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    class EmpresaManager
    {
        /// <summary>
        /// Testea el metodo getAll de la clase PersonManager. Comprobamos que el numero de resultados obtenidos se incrementa en uno al insertar. Y baja en uno al eliminar.
        /// </summary>
        [TestMethod]
        public void getAllTest()
        {
            List<Empresa> pers = new List<Empresa>();
            pers = EmpresaManager.getAll();
            int numero = pers.Count;

            Empresa p = new Empresa();
            p.nif = "75719295Y";
            p.nombre = "nector";
            p.email = "nectorosales@gmail.com";
            p.poblacion = "Almeria";
            p.telefono = "651880496";
            int id = EmpresaManager.add(p);

            pers = EmpresaManager.getAll();
            int numero2 = pers.Count;
            Assert.AreEqual(numero + 1, numero2);

            bool elimina = EmpresaManager.remove(id);
            pers = EmpresaManager.getAll();
            int numero3 = pers.Count;
            Assert.AreEqual(numero, numero3);

        }

        /// <summary>
        /// Testea el metodo get de la clase EmpresaManager. Comprobamos que devuelve la persona correcta indicandole su identificador.
        /// </summary>
        [TestMethod]
        public void getTest()
        {
            Empresa per = new Empresa();
            per = EmpresaManager.get(1);
            Assert.AreEqual(per.nombre, "jose");
        }

        /// <summary>
        /// Testea el metodo add de la clase  PersonManager. Comprobamos que al crear una persona no devuelve error. Lo eliminamos despues para que el test no afecte a la base de datos.
        /// </summary>
        [TestMethod]
        public void addTest()
        {

            Empresa p = new Empresa();
            p.nif = "75719295Y";
            p.nombre = "nector";
            p.email = "nectorosales@gmail.com";
            p.poblacion = "Almeria";
            p.telefono = "651880496";
            int id = EmpresaManager.add(p);
            Assert.AreNotEqual(id, -1);

            bool elimina = EmpresaManager.remove(id);

        }

        /// <summary>
        /// Testea el metodo remove de la clase PersonManager. Comprueba que el metodo devuelve true al eliminar. Antes se crea un usuario, para poder borrarlo y que no altere la base de datos.
        /// </summary>
        [TestMethod]
        public void removeTest()
        {
            Empresa p = new Empresa();
            p.nif = "75719295Y";
            p.nombre = "nector";
            p.email = "nectorosales@gmail.com";
            p.poblacion = "Almeria";
            p.telefono = "651880496";
            int id = EmpresaManager.add(p);

            bool elimina = EmpresaManager.remove(id);
            Assert.AreEqual(elimina, true);
        }
        
    }
}
