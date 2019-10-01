using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Vaisius");
            table.Columns.Add("Apvalumas", typeof(double));
            table.Columns.Add("Spalva", typeof(double));

            //  Duomenys
            table.Rows.Add("Obuolys", 0.21835, 0.81884);
            table.Rows.Add("Obuolys", 0.14115, 0.83535);
            table.Rows.Add("Obuolys", 0.37022, 0.8111);
            table.Rows.Add("Obuolys", 0.31565, 0.83101);
            //table.Rows.Add("Obuolys", 0.36484, 0.8518);
            //table.Rows.Add("Obuolys", 0.46111, 0.82518);
            //table.Rows.Add("Obuolys", 0.55223, 0.83449);
            //table.Rows.Add("Obuolys", 0.16975, 0.84049);
            table.Rows.Add("Obuolys", 0.49187, 0.80889);
            table.Rows.Add("Kriause", 0.14913, 0.77104);
            table.Rows.Add("Kriause", 0.18474, 0.6279);
            //table.Rows.Add("Kriause", 0.08838, 0.62068);
            table.Rows.Add("Kriause", 0.098166, 0.79092);

            //Kvieciama naive klase

            Klasifikatorius classifier = new Klasifikatorius();


            //string apvalumas, spalva;
            double apvalumas, spalva;
            int iterator = 0;
            while (true)
            {
                //ivedami duomenis yra saugomi ir klasifikatorius apsimoko pagal juos
                //klasifikatorius apmokomas su senais duomenimis
                classifier.TrainClassifier(table, iterator);
                //ivadame apvaluma, spalva
                apvalumas = double.Parse(Console.ReadLine());
                spalva = double.Parse(Console.ReadLine());

                //pridedame gautus duomenis i duomenu lentele
                DataRow new_row = table.NewRow();
                new_row["Vaisius"] = classifier.Classify(new double[] { apvalumas, spalva });
                new_row["Apvalumas"] = apvalumas;
                new_row["Spalva"] = spalva;
                table.Rows.Add(new_row);

                foreach (DataRow dr in table.Rows)
                {
                    StreamWriter sw = new StreamWriter("duomenu_lentele.txt", true); //create the file
                    string line = "Vaisius:" + dr["Vaisius"].ToString() + ";";
                    line += "Apvalumas:" + dr["Apvalumas"].ToString() + ";";
                    line += "Spalva:" + dr["Spalva"].ToString() + ";";
                    //and so on
                    sw.WriteLine(line); //write data
                    sw.Close();
                }


                //PArasome kriause ar obuolys 
                Console.WriteLine(classifier.Classify(new double[] { apvalumas, spalva }));
                Console.Read();
                iterator++;
            }
            //Console.Read();
        }
    }
    }

