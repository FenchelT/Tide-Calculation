using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerTest
{

        public class TestClass
        {
            // Der Delegat muß die gleiche Signatur aufweisen wie
            // die Eventhandler-Methode.
            public delegate void EventDelegate();
            // Das Event-Objekt ist vom Typ dieses Delegaten
            public event EventDelegate MyEvent;

            public void OnEvent()
            {
                // Prüft ob das Event überhaupt einen Abonnenten hat.
                if (MyEvent != null)
                    MyEvent();
            }

            // Exemplarische Methode,
            // die unter einer bestimmten Bedingung ein Event auslöst.
            public void Observable()
            {
                Random rnd = new Random();
                int result = rnd.Next(20);
                // Das Event wird gefeuert wenn result ungleich 0 ist.
                if (result != 0)
                    OnEvent();
            }
        }

        class Program
        {
            public static void Main()
            {
                TestClass tc = new TestClass();
                // Hier wird das Event abonniert.
                // Das kann jede Klasse auf die gleiche Weise machen.
                tc.MyEvent += new TestClass.EventDelegate(EventHandler);
                tc.Observable();
            }

            static void EventHandler()
            {
                Console.WriteLine("Event wurde ausgelöst.");
            Console.Read();
            }
        }
    }




