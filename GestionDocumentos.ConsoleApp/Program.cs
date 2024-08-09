using System;
using System.Collections.Generic;
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
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================");
                Console.WriteLine("  Bienvenido a rDOC - Gestión Efectiva de Documentos");
                Console.WriteLine("==================================================");
                Console.ResetColor();
                Console.WriteLine("\nElija una de estas opciones:");
                Console.WriteLine("1. Agregar documento");
                Console.WriteLine("2. Listar documentos");
                Console.WriteLine("3. Buscar documento");
                Console.WriteLine("4. Eliminar documento");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddDocumentUI(manager);
                        break;
                    case "2":
                        ListDocumentsUI(manager);
                        break;
                    case "3":
                        SearchDocumentsUI(manager);
                        break;
                    case "4":
                        DeleteDocumentUI(manager);
                        break;
                    case "5":
                        Console.WriteLine("\n¡Gracias por usar rDOC! Hasta pronto.");
                        return;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddDocumentUI(DocumentManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Agregar Nuevo Documento ===\n");
            
            Console.Write("Ingrese el nombre del documento: ");
            string name = Console.ReadLine();
            
            Console.WriteLine("\nIngrese el contenido del documento (presione Enter dos veces para finalizar):");
            string content = "";
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                content += line + "\n";
            }

            manager.AddDocument(new Document(name, content));
            
            Console.WriteLine("\nDocumento agregado exitosamente. Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void ListDocumentsUI(DocumentManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Documentos ===\n");
            manager.ListDocuments();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void SearchDocumentsUI(DocumentManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Buscar Documentos ===\n");
            Console.Write("Ingrese el término de búsqueda: ");
            string searchTerm = Console.ReadLine();
            manager.SearchDocuments(searchTerm);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void DeleteDocumentUI(DocumentManager manager)
        {
            Console.Clear();
            Console.WriteLine("=== Eliminar Documento ===\n");
            Console.Write("Ingrese el nombre del documento a eliminar: ");
            string docToDelete = Console.ReadLine();
            manager.DeleteDocument(docToDelete);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
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
                Console.WriteLine($"Nombre: {doc.Name}");
                Console.WriteLine($"Fecha de creación: {doc.CreationDate}");
                Console.WriteLine(new string('-', 30));
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
                Console.WriteLine($"Nombre: {doc.Name}");
                Console.WriteLine($"Fecha de creación: {doc.CreationDate}");
                Console.WriteLine(new string('-', 30));
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