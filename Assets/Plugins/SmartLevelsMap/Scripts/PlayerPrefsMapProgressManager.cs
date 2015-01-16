using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Assets.Plugins.SmartLevelsMap.Scripts
{
    public class PlayerPrefsMapProgressManager : IMapProgressManager
    {
        private string GetLevelKey(int number)
        {
            return string.Format("Level.{0:000}.StarsCount", number);
        }

        public int LoadLevelStarsCount(int level)
        {
            return Banco.fases[level-1].NumeroDeEstrelas();
        }

        public void SaveLevelStarsCount(int level, int starsCount)
        {
             PlayerPrefs.SetInt(GetLevelKey(level), starsCount);
        }

        public void ClearLevelProgress(int level)
        {
            Banco.Limpar();
           // PlayerPrefs.DeleteKey(GetLevelKey(level));
        }
    }

    [XmlRoot("FasesCollection")]
    public static class Banco
    {

        [XmlArray("Fases"), XmlArrayItem("Fases")]
        public static List<FaseClass> fases = new List<FaseClass>();
       
       

        public static void Save()
        {
             var serializer = new XmlSerializer(typeof(List<FaseClass>));
            var stream = new FileStream(Application.persistentDataPath + "/savedGames.xml", FileMode.Create);
            serializer.Serialize(stream, fases);
            stream.Close();
        }

        public static void Load()
        {
            Fases x = new Fases();
            if (File.Exists(Application.persistentDataPath + "/savedGames.xml"))
            {

                var serializer = new XmlSerializer(typeof(List<FaseClass>));
                using (var stream = new FileStream(Application.persistentDataPath + "/savedGames.xml", FileMode.Open))
                {
                    fases = serializer.Deserialize(stream) as List<FaseClass>;
                }
            }
            else
            {
				Iniciar();
            }
        }

        public static void Limpar()
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.xml"))
            {
                File.Delete(Application.persistentDataPath + "/savedGames.xml");
                fases.Clear();
            }
			Iniciar();
        }

        public static void Zerar()
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames.xml"))
            {
                File.Delete(Application.persistentDataPath + "/savedGames.xml");
                fases.Clear();
            }
           
            for (int i = 1; i < Fases.vetordefases.Count; i++)
            {

                fases.Add(new FaseClass(Fases.vetordefases[i - 1].ToString(), "Fase" + i.ToString(), 10, true, true, true, true));

            }
            Save();
        }

		public static void Iniciar()
		{

			fases.Add (new FaseClass (Fases.vetordefases[0].ToString(),"Fase1", -1, false, false, false, true));

			for (int i = 2; i<Fases.vetordefases.Count+1; i++) {
                fases.Add(new FaseClass(Fases.vetordefases[i-1].ToString(),"Fase" + i.ToString(), -1, false, false, false, false));
        
               
			}
            
          	Save();

		}


        public static int TotalDeEstrelas()
        {
            int ct = 0;
            foreach (FaseClass f in fases)
            {
                if (f.aberta && f.NumeroDeEstrelas() > 0)
                {
                    ct += f.NumeroDeEstrelas();
                }
            }
            return ct;
        }

    }

    public class FaseClass
    {

        [XmlAttribute("nome")]
        public string nome;
        [XmlAttribute("fase")]
        public string fase;
        [XmlAttribute("tempo")]
        public float tempo;
       // [XmlAttribute("estrela1")]
        public bool estrela1;
       // [XmlAttribute("estrela1")]
        public bool estrela2;
       // [XmlAttribute("estrela1")]
        public bool estrela3;
       // [XmlAttribute("estrela1")]
        public bool aberta;

        public FaseClass()
        {
        }


        public FaseClass(string nome, string fase, float tempo, bool estrela1, bool estrela2, bool estrela3, bool aberta)
        {
            this.nome = nome;
            this.fase = fase;
            this.tempo = tempo;
            this.estrela1 = estrela1;
            this.estrela2 = estrela2;
            this.estrela3 = estrela3;
            this.aberta = aberta;
        }

        public string ToString()
        {
            string str = "";

            str += "nome = " + nome;
            
            str += "  fase = " + fase;
            str += "  tempo = " + tempo;
            str += "  estrela1 = " + estrela1;
            str += "  estrela2 = " + estrela2;
            str += "  estrela3 = " + estrela3;
            str += "  aberta = " + aberta;

            return str;
        }

        public int NumeroDeEstrelas()
        {
            int nestrelas = 0;
            if (estrela1) { nestrelas++; }
            if (estrela2) { nestrelas++; }
            if (estrela3) { nestrelas++; }
            return nestrelas;
        }
    }

}
