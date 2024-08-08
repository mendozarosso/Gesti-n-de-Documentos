using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentManager manager = new DocumentManager();
            
            while (true)
            {
                Console.WriteLine("Bienvenido a RDOC, La solucion Efectiva para el manejo de documentos");
                Console.WriteLine("Elige Una de estas opciones : ");
                Console.WriteLine("\n1. Agregar documento");
                Console.WriteLine("2. Listar documentos");
                Console.WriteLine("3. Buscar documento");
                Console.WriteLine("4. Eliminar documento");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();
                Console.WriteLine("Bienvenido a RDOC, La solucion Efectiva para el manejo de documentos");
                Console.WriteLine("Elige Una de estas opciones : ");

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del documento: ");
                        string name = Console.ReadLine();
                        Console.Write("Ingrese el contenido del documento: ");
                        string content = Console.ReadLine();
                        manager.AddDocument(new Document(name, content));
                        break;
                    case "2":
                        manager.ListDocuments();
                        break;
                    case "3":
                        Console.Write("Ingrese el término de búsqueda: ");
                        string searchTerm = Console.ReadLine();
                        manager.SearchDocuments(searchTerm);
                        break;
                    case "4":
                        Console.Write("Ingrese el nombre del documento a eliminar: ");
                        string docToDelete = Console.ReadLine();
                        manager.DeleteDocument(docToDelete);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }

    class Document
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public Document(string name, string content)
        {
            Name = name;
            Content = content;
            CreationDate = DateTime.Now;
        }
    }

    class DocumentManager
    {
        private List<Document> documents = new List<Document>();

        public void AddDocument(Document doc)
        {
            documents.Add(doc);
            Console.WriteLine("Documento agregado exitosamente.");
        }

        public void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No hay documentos en el sistema.");
                return;
            }

            foreach (var doc in documents)
            {
                Console.WriteLine($"Nombre: {doc.Name}, Fecha de creación: {doc.CreationDate}");
            }
        }

        public void SearchDocuments(string searchTerm)
        {
            var results = documents.Where(d => d.Name.Contains(searchTerm) || d.Content.Contains(searchTerm)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No se encontraron documentos que coincidan con la búsqueda.");
                return;
            }

            foreach (var doc in results)
            {
                Console.WriteLine($"Nombre: {doc.Name}, Fecha de creación: {doc.CreationDate}");
            }
        }

        public void DeleteDocument(string name)
        {
            var docToDelete = documents.FirstOrDefault(d => d.Name == name);
            if (docToDelete != null)
            {
                documents.Remove(docToDelete);
                Console.WriteLine("Documento eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el documento especificado.");
            }
        }
    }
}