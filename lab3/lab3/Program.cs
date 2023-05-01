using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace lab3
{
    class Program
    {
        public class probClientes
        {
            //public string dpi { get; set; }
            public long dpi { get; set; }
            public int budget { get; set; }
           
        }

        public class Subasta
        {
            public string property { get; set; }
            public List<probClientes> customers { get; set; }
            public int rejection { get; set; }

        }


        public class signContrato
        {
            //public string dpi { get; set; }
            public long dpi { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime birthDate { get; set; }
            public string job { get; set; }
            public string placeJob { get; set; }
            public int salary { get; set; }
            public string property { get; set; }
            public int budget { get; set; }
            public string signature { get; set; }

        }
        public class preContrato 
        {
            //public string dpi { get; set; }
            public long dpi { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime birthDate { get; set; }
            public string job { get; set; }
            public string placeJob { get; set; }
            public int salary { get; set; }
            public string property { get; set; }
            public int budget { get; set; }

        }
        public class Clientes : IComparable<Clientes>
        {
            //public string dpi { get; set; }
            public long dpi { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public DateTime birthDate { get; set; }
            public string job { get; set; }
            public string placeJob { get; set; }
            public int salary { get; set; }

            public int CompareTo(Clientes other)
            {
                if (this.dpi > other.dpi)
                {
                    return 1;
                }
                else if (this.dpi < other.dpi)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            public int CompareTo(string other)
            {
                if (this.dpi > long.Parse(other))
                {
                    return 1;
                }
                else if (this.dpi < long.Parse(other))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

           
        }
        public class InputLab
        {

            public List<Clientes> input1 { get; set; }

        }

        class Node<T>
        {
            public Node<T> LeftNode { get; set; }
            public Node<T> RightNode { get; set; }
            public T Data { get; set; }
        }

        class BinaryTree<T>
        {
            public Node<T> Root { get; set; }

            public bool Add(T value)
            {
                Node<T> before = null, after = this.Root;

                while (after != null)
                {
                    before = after;
                    if (Comparer<T>.Default.Compare(value, after.Data) < 0) //Is new node in left tree? 
                        after = after.LeftNode;
                    else if (Comparer<T>.Default.Compare(value, after.Data) > 0) //Is new node in right tree?
                        after = after.RightNode;
                    else
                    {
                        //Exist same value
                        return false;
                    }
                }

                Node<T> newNode = new Node<T>();
                newNode.Data = value;

                if (this.Root == null)//Tree ise empty
                    this.Root = newNode;
                else
                {
                    if (Comparer<T>.Default.Compare(value, before.Data) < 0)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }

                return true;
            }

            public Node<T> Find(T value)
            {
                return this.Find(value, this.Root);
            }

            private Node<T> Find(T value, Node<T> parent)
            {
                if (parent != null)
                {
                    if (Comparer<T>.Default.Compare(value, parent.Data) == 0) return parent;
                    if (Comparer<T>.Default.Compare(value, parent.Data) < 0)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }



        }


        static void Main(string[] args)
        {
            BinaryTree<Clientes> binaryTree = new BinaryTree<Clientes>();

            Clientes clienteGanador = new Clientes();
            Node<Clientes> clienteInfo = new Node<Clientes>();

            string text = File.ReadAllText(@"C:\Users\Rolando Ziller\source\repos\lab3\lab3\datos\input_customer_challenge_lab_3.jsonl");
            string[] words = text.Split('\n');


            foreach (var item in words)
            {
                Clientes input = JsonSerializer.Deserialize<Clientes>(item)!;
                //Console.WriteLine($"Id: {input.dpi}" + " " + $"Primer nombre: {input.firstName}" + " " + $"Segundo nombre: {input.lastName}" + " " + $"Fecha de nacimiento: {input.birthDate}" + " " + $"Trabajo: {input.job}" + " " + $"Lugar de trabajo: {input.placeJob}" + " " + $"Salario: {input.salary}");
                //Console.WriteLine("----------------------");
                //Console.WriteLine("");

                binaryTree.Add(input);
            }

            //Console.WriteLine(binaryTree);


            string text2 = File.ReadAllText(@"C:\Users\Rolando Ziller\source\repos\lab3\lab3\datos\input_auctions_challenge_lab_3.jsonl");
            string[] words2 = text2.Split('\n');

            for (int i = 0; i < words2.Length; i++)
            {

                //Clientes input = JsonSerializer.Deserialize<Clientes>(words[i])!;

                
                Subasta inputSubasta = JsonSerializer.Deserialize<Subasta>(words2[i])!;

                //Console.WriteLine($"Id: {input.dpi}" + " " + $"Primer nombre: {input.firstName}" + " " + $"Segundo nombre: {input.lastName}" + " " + $"Fecha de nacimiento: {input.birthDate}" + " " + $"Trabajo: {input.job}" + " " + $"Lugar de trabajo: {input.placeJob}" + " " + $"Salario: {input.salary}");
                //Console.WriteLine("----------------------");
                //Console.WriteLine("");
                //binaryTree.Add(input);


                //Console.WriteLine(input);
                /*foreach (Clientes itemInput1 in input)
                {
                    Console.WriteLine($"Id: {itemInput1.dpi}" + " " + $"Primer nombre: {itemInput1.firstName}" + " " + $"Segundo nombre: {itemInput1.lastName}" + " " + $"Fecha de nacimiento: {itemInput1.birthDate}" + " " + $"Trabajo: {itemInput1.job}" + " " + $"Lugar de trabajo: {itemInput1.placeJob}" + " " + $"Salario: {itemInput1.salary}");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("");
                    binaryTree.Add(itemInput1);


                }*/

                //Console.WriteLine(inputSubasta.property);

                List<probClientes> clients = new List<probClientes>();
                foreach (probClientes itemInput2 in inputSubasta.customers)
                {
                    //Console.WriteLine(itemInput2.dpi);
                    //Console.WriteLine(itemInput2.Budget);

                    clients.Add(itemInput2);


                }

                clients.Sort(delegate (probClientes x, probClientes y) {
                    return y.budget.CompareTo(x.budget);
                });

                //Console.WriteLine(inputSubasta.rejection);

                probClientes ganador = clients[inputSubasta.rejection];

                //Console.WriteLine(ganador.budget);

                clienteGanador.dpi = ganador.dpi;

                clienteInfo = binaryTree.Find(clienteGanador);

                preContrato bsObj = new preContrato()
                {
                    dpi = clienteInfo.Data.dpi,
                    firstName = clienteInfo.Data.firstName,
                    lastName = clienteInfo.Data.lastName,
                    birthDate = clienteInfo.Data.birthDate,
                    job = clienteInfo.Data.job,
                    placeJob = clienteInfo.Data.placeJob,
                    salary = clienteInfo.Data.salary,
                    property = inputSubasta.property,
                    budget = ganador.budget
                };

                string jsonData = JsonSerializer.Serialize(bsObj);
                //Console.WriteLine(jsonData);

                static string ComputeSha256Hash(string rawData)
                {
                    // Create a SHA256   
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        // ComputeHash - returns byte array  
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                        // Convert byte array to a string   
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        return builder.ToString();
                    }
                }

                //Console.WriteLine("");
                string hashedData = ComputeSha256Hash(jsonData);
                //Console.WriteLine("Hash {0}", hashedData);

                //Console.WriteLine("");


                signContrato bsObjFinal = new signContrato()
                {
                    dpi = clienteInfo.Data.dpi,
                    firstName = clienteInfo.Data.firstName,
                    lastName = clienteInfo.Data.lastName,
                    birthDate = clienteInfo.Data.birthDate,
                    job = clienteInfo.Data.job,
                    placeJob = clienteInfo.Data.placeJob,
                    salary = clienteInfo.Data.salary,
                    property = inputSubasta.property,
                    budget = ganador.budget,
                    signature = hashedData
                };

                string jsonDataFinal = JsonSerializer.Serialize(bsObjFinal);
                //Console.WriteLine("Ganador");
                Console.WriteLine(jsonDataFinal);


            }
            /*clienteGanador.dpi = "3691215182123";

            clienteInfo = binaryTree.Find(clienteGanador);

            preContrato bsObj = new preContrato()
            {
                dpi = clienteInfo.Data.dpi,
                firstName = clienteInfo.Data.firstName,
                lastName = clienteInfo.Data.lastName,
                birthDate = clienteInfo.Data.birthDate,
                job = clienteInfo.Data.job,
                placeJob = clienteInfo.Data.placeJob,
                salary = clienteInfo.Data.salary,
                property = "A-123",
                budget = 1500
            };

            string jsonData = JsonSerializer.Serialize(bsObj);
            Console.WriteLine(jsonData);

            static string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }

            Console.WriteLine("");
            string hashedData = ComputeSha256Hash(jsonData);
            Console.WriteLine("Hash {0}", hashedData);

            Console.WriteLine("");


            signContrato bsObjFinal = new signContrato()
            {
                dpi = clienteInfo.Data.dpi,
                firstName = clienteInfo.Data.firstName,
                lastName = clienteInfo.Data.lastName,
                birthDate = clienteInfo.Data.birthDate,
                job = clienteInfo.Data.job,
                placeJob = clienteInfo.Data.placeJob,
                salary = clienteInfo.Data.salary,
                property = "A-123",
                budget = 1500,
                signature = hashedData
            };

            string jsonDataFinal = JsonSerializer.Serialize(bsObjFinal);
            Console.WriteLine(jsonDataFinal);*/


        }
    }
}
