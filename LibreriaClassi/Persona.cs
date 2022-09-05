using System;

namespace Classi
{
    public class Persona : IComparable<Persona>
    {
        private string mNome;
        private string mCognome;
        private DateTime mDataNascita;

        // *****************************
        // Properties

        public string Nome
        {
            get { return mNome; }
            set { mNome = value; }
        }

        public string Cognome
        {
            get { return mCognome; }
            set { mCognome = value; }
        }

        public DateTime DataNascita
        {
            get { return mDataNascita; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new Exception("Birth date not correct");
                }

                mDataNascita = value;
            }
        }

        // *****************************
        // Constructors

        public Persona()
        {
            mNome = "";
            mCognome = "";
            mDataNascita = DateTime.Now;
        }

        public Persona(string nome, string cognome, DateTime dataNascita)
        {
            mNome = nome;
            mCognome = cognome;
            mDataNascita = dataNascita;
        }

        public int CompareTo(Persona other)
        {
            if (other == null) return 0;

            if (
                other.DataNascita > this.mDataNascita
                )
            {
                return -1;
            } else
            {
                return 1;
            }
        }

        // ***********************************
        // Overrides

        public override string ToString()
        {
            return Nome + "          " + Cognome + "                        " + DataNascita.Day + "/" + DataNascita.Month + "/" + DataNascita.Year;
        }
    }
}