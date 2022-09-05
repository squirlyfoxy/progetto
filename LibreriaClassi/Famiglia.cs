using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Classi
{
    public class Famiglia
    {
        public const string XML_FILE_NAME = "Persone.xml";

        private List<Persona> mComponenti;

        // ***************************
        // Properties

        public List<Persona> Componenti
        {
            get { return mComponenti; }
            set { mComponenti = value; }
        }

        public Famiglia()
        {
            mComponenti = new List<Persona>();
        }

        // ***************************
        // Methods

        public List<Persona> SorComponentiFamigliaDataNascita()
        {
            List<Persona> appoggio = mComponenti;
            appoggio.Sort();
            return appoggio;
        }

        public static Famiglia Deserializza()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Famiglia));
            StreamReader sr = new StreamReader(XML_FILE_NAME);

            Famiglia famiglia = (Famiglia)serializer.Deserialize(sr);
            if (famiglia == null)
                throw new Exception("Errore nella deserializzazione del file");

            sr.Close();

            return famiglia;
        }

        public static void Serializza(Famiglia b)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Famiglia));
            StreamWriter sw = new StreamWriter(XML_FILE_NAME);
            serializer.Serialize(sw, b);
            sw.Close();
        }
    }
}
